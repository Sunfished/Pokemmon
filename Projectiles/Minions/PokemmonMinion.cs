using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Pokemmon.Buffs;
using static Terraria.ModLoader.ModContent;

namespace Pokemmon.Projectiles.Minions
{
	public abstract class PokemmonMinion : ModProjectile
	{		
		//buff ID
		public int myBuffID;
		
		//type buff effects
		public bool normalType;
		public bool grassType;
		public bool fireType;
		public bool waterType;
		public bool electricType;
		public bool flyingType;
		public bool bugType;
		public bool fightingType;
		public bool poisonType;
		public bool rockType;
		public bool groundType;
		public bool steelType;
		public bool iceType;
		public bool psychicType;
		public bool darkType;
		public bool ghostType;
		public bool dragonType;
		public bool fairyType;
		
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
		
		public override bool? CanCutTiles() {
			return false;
		}

		public override bool MinionContactDamage() {
			return true;
		}
		
		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			
			#region Active check
			// This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
			if (player.dead || !player.active) {
				player.ClearBuff(myBuffID);
			}
			if (player.HasBuff(myBuffID)) {
				Projectile.timeLeft = 2;
			}
			#endregion
			
			//flying types can fly
			//water types can swim when submerged in water
			if (flyingType || (waterType && Projectile.wet))
				AIWalker();//AIFlyer();
			//Handle AI
			else
				AIWalker();
			
			//Rotate Sprite to facing
			Projectile.spriteDirection = Projectile.direction;
			if (Math.Abs(Projectile.velocity.X) < 0.1f && Projectile.velocity.Y >= -0.2f)
				Projectile.spriteDirection = player.direction;
			
			//Type Buff Effects
			if (fireType)
				Lighting.AddLight(Projectile.Center, Color.White.ToVector3() * 0.78f);
		}
		
		
		public void AIFlyer()
		{
			Player player = Main.player[Projectile.owner];

			#region General behavior
			Vector2 idlePosition = player.Center;
			idlePosition.Y -= 48f; // Go up 48 coordinates (three tiles from the center of the player)

			// If your minion doesn't aimlessly move around when it's idle, you need to "put" it into the line of other summoned minions
			// The index is projectile.minionPos
			float minionPositionOffsetX = (Projectile.width + Projectile.minionPos * Projectile.width) * -player.direction;
			idlePosition.X += minionPositionOffsetX; // Go behind the player

			// All of this code below this line is adapted from Spazmamini code (ID 388, aiStyle 66)

			// Teleport to player if distance is too big
			Vector2 vectorToIdlePosition = idlePosition - Projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f) {
				// Whenever you deal with non-regular events that change the behavior or position drastically, make sure to only run the code on the owner of the projectile,
				// and then set netUpdate to true
				Projectile.position = idlePosition;
				Projectile.velocity *= 0.1f;
				Projectile.netUpdate = true;
			}

			// If your minion is flying, you want to do this independently of any conditions
			float overlapVelocity = 0.04f;
			for (int i = 0; i < Main.maxProjectiles; i++) {
				// Fix overlap with other minions
				Projectile other = Main.projectile[i];
				if (i != Projectile.whoAmI && other.active && other.owner == Projectile.owner && Math.Abs(Projectile.position.X - other.position.X) + Math.Abs(Projectile.position.Y - other.position.Y) < Projectile.width) {
					if (Projectile.position.X < other.position.X) Projectile.velocity.X -= overlapVelocity;
					else Projectile.velocity.X += overlapVelocity;

					if (Projectile.position.Y < other.position.Y) Projectile.velocity.Y -= overlapVelocity;
					else Projectile.velocity.Y += overlapVelocity;
				}
			}
			#endregion

			#region Find target
			// Starting search distance
			float distanceFromTarget = 700f;
			Vector2 targetCenter = Projectile.position;
			bool foundTarget = false;

			// This code is required if your minion weapon has the targeting feature
			if (player.HasMinionAttackTargetNPC) {
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, Projectile.Center);
				// Reasonable distance away so it doesn't target across multiple screens
				if (between < 2000f) {
					distanceFromTarget = between;
					targetCenter = npc.Center;
					foundTarget = true;
				}
			}
			if (!foundTarget) {
				// This code is required either way, used for finding a target
				for (int i = 0; i < Main.maxNPCs; i++) {
					NPC npc = Main.npc[i];
					if (npc.CanBeChasedBy()) {
						float between = Vector2.Distance(npc.Center, Projectile.Center);
						bool closest = Vector2.Distance(Projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(Projectile.position, Projectile.width, Projectile.height, npc.position, npc.width, npc.height);
						// Additional check for this specific minion behavior, otherwise it will stop attacking once it dashed through an enemy while flying though tiles afterwards
						// The number depends on various parameters seen in the movement code below. Test different ones out until it works alright
						bool closeThroughWall = between < 100f;
						if (((closest && inRange) || !foundTarget) && (lineOfSight || closeThroughWall)) {
							distanceFromTarget = between;
							targetCenter = npc.Center;
							foundTarget = true;
						}
					}
				}
			}

			// friendly needs to be set to true so the minion can deal contact damage
			// friendly needs to be set to false so it doesn't damage things like target dummies while idling
			// Both things depend on if it has a target or not, so it's just one assignment here
			// You don't need this assignment if your minion is shooting things instead of dealing contact damage
			Projectile.friendly = foundTarget;
			#endregion

			#region Movement

			// Default movement parameters (here for attacking)
			float speed = 8f;
			float inertia = 20f;

			if (foundTarget) {
				// Minion has a target: attack (here, fly towards the enemy)
				if (distanceFromTarget > 40f) {
					// The immediate range around the target (so it doesn't latch onto it when close)
					Vector2 direction = targetCenter - Projectile.Center;
					direction.Normalize();
					direction *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + direction) / inertia;
				}
			}
			else {
				// Minion doesn't have a target: return to player and idle
				if (distanceToIdlePosition > 600f) {
					// Speed up the minion if it's away from the player
					speed = 12f;
					inertia = 60f;
				}
				else {
					// Slow down the minion if closer to the player
					speed = 4f;
					inertia = 80f;
				}
				if (distanceToIdlePosition > 20f) {
					// The immediate range around the player (when it passively floats about)

					// This is a simple movement formula using the two parameters and its desired direction to create a "homing" movement
					vectorToIdlePosition.Normalize();
					vectorToIdlePosition *= speed;
					Projectile.velocity = (Projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (Projectile.velocity == Vector2.Zero) {
					// If there is a case where it's not moving at all, give it a little "poke"
					Projectile.velocity.X = -0.15f;
					Projectile.velocity.Y = -0.05f;
				}
			}
			Projectile.velocity = Collision.TileCollision(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
			Collision.StepUp(ref Projectile.position, ref Projectile.velocity, Projectile.width, Projectile.height, ref Projectile.stepSpeed, ref Projectile.gfxOffY);
			#endregion

			#region Animation and visuals
			// So it will lean slightly towards the direction it's moving
			Projectile.rotation = Projectile.velocity.X * 0.05f;
			#endregion
		}
		
		public void AIWalker()
		{
			Player player = Main.player[Projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			
			////////
			//IDLE//
			////////
			Vector2 idlePosition = player.Center;
			float minionPositionOffsetX = (Projectile.width + Projectile.minionPos * Projectile.width) * -player.direction;
			idlePosition.X += minionPositionOffsetX; // Go behind the player
			Vector2 moveToPosition = idlePosition;

			int targetID = -1;
			float searchDist = 700f;
			
			int num830 = 15;
			if (Projectile.ai[0] == 0f)
			{
				NPC thisTarget = Projectile.OwnerMinionAttackTargetNPC;
				if (thisTarget != null && thisTarget.CanBeChasedBy(this))
				{
					float distanceTargetToProjectile = (thisTarget.Center - Projectile.Center).Length();
					if (distanceTargetToProjectile < searchDist)
					{
						targetID = thisTarget.whoAmI;
						searchDist = distanceTargetToProjectile;
					}
				}
				if (targetID < 0)
				{
					for (int i = 0; i < 200; i++)
					{
						NPC thisNPC = Main.npc[i];
						if (thisNPC.CanBeChasedBy(this))
						{
							float distanceProjectileToNPC = (thisNPC.Center - Projectile.Center).Length();
							if (distanceProjectileToNPC < searchDist)
							{
								targetID = i;
								searchDist = distanceProjectileToNPC;
							}
						}
					}
				}
				Projectile.friendly = targetID != -1;
			}
			if (Projectile.ai[0] == 1f)
			{
				Projectile.tileCollide = false;
				float num834 = 0.2f;
				float num835 = 10f;
				int maxDist = 200;
				if (num835 < Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y))
				{
					num835 = Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y);
				}
				Vector2 distancePlayerToProjectile = player.Center - Projectile.Center;
				float lengthPlayerToProjectile = distancePlayerToProjectile.Length();
				
				//Jump to player if projectile is way too far away
				if (lengthPlayerToProjectile > 2000f)
				{
					Projectile.position = player.Center - new Vector2(Projectile.width, Projectile.height) / 2f;
				}
				
				if (lengthPlayerToProjectile < (float)maxDist && player.velocity.Y == 0f && Projectile.position.Y + (float)Projectile.height <= player.position.Y + (float)player.height && !Collision.SolidCollision(Projectile.position, Projectile.width, Projectile.height))
				{
					Projectile.ai[0] = 0f;
					Projectile.netUpdate = true;
					if (Projectile.velocity.Y < -6f)
					{
						Projectile.velocity.Y = -6f;
					}
				}
				
				//Rocket Back to player
				if (!(lengthPlayerToProjectile < 60f))
				{
					distancePlayerToProjectile.Normalize();
					distancePlayerToProjectile *= num835;
					if (Projectile.velocity.X < distancePlayerToProjectile.X)
					{
						Projectile.velocity.X += num834;
						if (Projectile.velocity.X < 0f)
						{
							Projectile.velocity.X += num834 * 1.5f;
						}
					}
					if (Projectile.velocity.X > distancePlayerToProjectile.X)
					{
						Projectile.velocity.X -= num834;
						if (Projectile.velocity.X > 0f)
						{
							Projectile.velocity.X -= num834 * 1.5f;
						}
					}
					if (Projectile.velocity.Y < distancePlayerToProjectile.Y)
					{
						Projectile.velocity.Y += num834;
						if (Projectile.velocity.Y < 0f)
						{
							Projectile.velocity.Y += num834 * 1.5f;
						}
					}
					if (Projectile.velocity.Y > distancePlayerToProjectile.Y)
					{
						Projectile.velocity.Y -= num834;
						if (Projectile.velocity.Y > 0f)
						{
							Projectile.velocity.Y -= num834 * 1.5f;
						}
					}
				}
				if (Projectile.velocity.X != 0f)
				{
					Projectile.spriteDirection = Math.Sign(Projectile.velocity.X);
				}
				Projectile.rotation = Projectile.velocity.X * 0.1f;
			}
			
			//Seems to handle some sort of timer
			if (Projectile.ai[0] == 2f)
			{
				Projectile.friendly = true;
				Projectile.spriteDirection = Projectile.direction;
				Projectile.rotation = 0f;
				Projectile.velocity.Y += 0.4f;
				if (Projectile.velocity.Y > 10f)
				{
					Projectile.velocity.Y = 10f;
				}
				Projectile.ai[1]--;
				if (Projectile.ai[1] <= 0f)
				{
					Projectile.ai[1] = 0f;
					Projectile.ai[0] = 0f;
					Projectile.friendly = false;
					Projectile.netUpdate = true;
					return;
				}
			}
			if (targetID >= 0)
			{
				float num839 = 400f;
				float num840 = 20f;
				num839 = 700f;
				if ((double)Projectile.position.Y > Main.worldSurface * 16.0)
				{
					num839 *= 0.7f;
				}
				NPC target = Main.npc[targetID];
				Vector2 targetCenter = target.Center;
				float num841 = (targetCenter - Projectile.Center).Length();
				bool flag21 = Collision.CanHit(Projectile.position, Projectile.width, Projectile.height, target.position, target.width, target.height);
				if (num841 < num839)
				{
					moveToPosition = targetCenter;
					
					//Alter Jumps based on height
					if (targetCenter.Y < Projectile.Center.Y - 30f && Projectile.velocity.Y == 0f)
					{
						float distanceTargetToProjectile = Math.Abs(targetCenter.Y - Projectile.Center.Y);
						if (distanceTargetToProjectile < 120f)
						{
							Projectile.velocity.Y = -10f;
						}
						else if (distanceTargetToProjectile < 210f)
						{
							Projectile.velocity.Y = -13f;
						}
						else if (distanceTargetToProjectile < 270f)
						{
							Projectile.velocity.Y = -15f;
						}
						else if (distanceTargetToProjectile < 310f)
						{
							Projectile.velocity.Y = -17f;
						}
						else if (distanceTargetToProjectile < 380f)
						{
							Projectile.velocity.Y = -18f;
						}
					}//*/
				}
				if (num841 < num840)
				{
					Projectile.ai[0] = 2f;
					Projectile.ai[1] = num830;
					Projectile.netUpdate = true;
				}
			}
			if (Projectile.ai[0] == 0f && targetID < 0)
			{
				float num843 = 500f;
				if (Main.player[Projectile.owner].rocketDelay2 > 0)
				{
					Projectile.ai[0] = 1f;
					Projectile.netUpdate = true;
				}
				Vector2 vector68 = player.Center - Projectile.Center;
				if (vector68.Length() > 2000f)
				{
					Projectile.position = player.Center - new Vector2(Projectile.width, Projectile.height) / 2f;
				}
				else if (vector68.Length() > num843 || Math.Abs(vector68.Y) > 300f)
				{
					Projectile.ai[0] = 1f;
					Projectile.netUpdate = true;
					if (Projectile.velocity.Y > 0f && vector68.Y < 0f)
					{
						Projectile.velocity.Y = 0f;
					}
					if (Projectile.velocity.Y < 0f && vector68.Y > 0f)
					{
						Projectile.velocity.Y = 0f;
					}
				}
			}
			if (Projectile.ai[0] == 0f)
			{
				Projectile.tileCollide = true;
				float num844 = 0.5f;
				float num845 = 4f;
				float num846 = 4f;
				float num847 = 0.1f;
				if (num846 < Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y))
				{
					num846 = Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y);
					num844 = 0.7f;
				}
				int num849 = 0;
				bool flag22 = false;
				float distanceMovePositionToProjectile = moveToPosition.X - Projectile.Center.X;
				
				//Movement Control?
				if (Math.Abs(distanceMovePositionToProjectile) > 5f)
				{
					if (distanceMovePositionToProjectile < 0f)
					{
						num849 = -1;
						if (Projectile.velocity.X > 0f - num845)
						{
							Projectile.velocity.X -= num844;
						}
						else
						{
							Projectile.velocity.X -= num847;
						}
					}
					else
					{
						num849 = 1;
						if (Projectile.velocity.X < num845)
						{
							Projectile.velocity.X += num844;
						}
						else
						{
							Projectile.velocity.X += num847;
						}
					}
					flag22 = true;
				}
				
				//Slow Down Movement
				else
				{
					Projectile.velocity.X *= 0.9f;
					if (Math.Abs(Projectile.velocity.X) < num844 * 2f)
					{
						Projectile.velocity.X = 0f;
					}
				}
				if (num849 != 0)
				{
					int num851 = (int)(Projectile.position.X + (float)(Projectile.width / 2)) / 16;
					int num852 = (int)Projectile.position.Y / 16;
					num851 += num849;
					num851 += (int)Projectile.velocity.X;
					for (int i = num852; i < num852 + Projectile.height / 16 + 1; i++)
					{
						if (WorldGen.SolidTile(num851, i))
						{
							flag22 = true;
						}
					}
				}
				Collision.StepUp(ref Projectile.position, ref Projectile.velocity, Projectile.width, Projectile.height, ref Projectile.stepSpeed, ref Projectile.gfxOffY);
				if (Projectile.velocity.Y == 0f && flag22)
				{
					for (int i = 0; i < 3; i++)
					{
						int tileX = (int)(Projectile.position.X + (float)(Projectile.width / 2)) / 16;
						if (i == 0)
						{
							tileX = (int)Projectile.position.X / 16;
						}
						if (i == 2)
						{
							tileX = (int)(Projectile.position.X + (float)Projectile.width) / 16;
						}
						int tileY = (int)(Projectile.position.Y + (float)Projectile.height) / 16;
						if (!WorldGen.SolidTile(tileX, tileY) && !Main.tile[tileX, tileY].IsHalfBlock && Main.tile[tileX, tileY].Slope <= 0 && (!TileID.Sets.Platforms[Main.tile[tileX, tileY].TileType] || !Main.tile[tileX, tileY].HasTile || Main.tile[tileX, tileY].IsActuated))
						{
							continue;
						}
						try
						{
							tileX = (int)(Projectile.position.X + (float)(Projectile.width / 2)) / 16;
							tileY = (int)(Projectile.position.Y + (float)(Projectile.height / 2)) / 16;
							tileX += num849;
							tileX += (int)Projectile.velocity.X;
							if (!WorldGen.SolidTile(tileX, tileY - 1) && !WorldGen.SolidTile(tileX, tileY - 2))
							{
								//dummy code so that pokemon don't keep hopping around??
							}
							else if (!WorldGen.SolidTile(tileX, tileY - 2))
							{
								Projectile.velocity.Y = -7.1f;
							}
							else if (WorldGen.SolidTile(tileX, tileY - 5))
							{
								Projectile.velocity.Y = -11.1f;
							}
							else if (WorldGen.SolidTile(tileX, tileY - 4))
							{
								Projectile.velocity.Y = -10.1f;
							}
							else
							{
								Projectile.velocity.Y = -9.1f;
							}//*/
						}
						catch
						{
							Projectile.velocity.Y = -9.1f;
						}
					}
				}
				if (Projectile.velocity.X > num846)
				{
					Projectile.velocity.X = num846;
				}
				
				Projectile.spriteDirection = Projectile.direction;
				Projectile.rotation = 0f;
				Projectile.velocity.Y += 0.4f;
				if (Projectile.velocity.Y > 10f)
				{
					Projectile.velocity.Y = 10f;
				}
			}
		}
	}	
}