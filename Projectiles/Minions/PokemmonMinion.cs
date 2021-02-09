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
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			
			#region Active check
			// This is the "active check", makes sure the minion is alive while the player is alive, and despawns if not
			if (player.dead || !player.active) {
				player.ClearBuff(myBuffID);
			}
			if (player.HasBuff(myBuffID)) {
				projectile.timeLeft = 2;
			}
			#endregion
			
			//flying types can fly
			//water types can swim when submerged in water
			if (flyingType || (waterType && projectile.wet))
				AIWalker();//AIFlyer();
			//Handle AI
			else
				AIWalker();
			
			//Rotate Sprite to facing
			projectile.spriteDirection = projectile.direction;
			if (Math.Abs(projectile.velocity.X) < 0.1f && projectile.velocity.Y >= -0.2f)
				projectile.spriteDirection = player.direction;
			
			//Type Buff Effects
			if (fireType)
				Lighting.AddLight(projectile.Center, Color.White.ToVector3() * 0.78f);
		}
		
		
		public void AIFlyer()
		{
			Player player = Main.player[projectile.owner];

			#region General behavior
			Vector2 idlePosition = player.Center;
			idlePosition.Y -= 48f; // Go up 48 coordinates (three tiles from the center of the player)

			// If your minion doesn't aimlessly move around when it's idle, you need to "put" it into the line of other summoned minions
			// The index is projectile.minionPos
			float minionPositionOffsetX = (projectile.width + projectile.minionPos * projectile.width) * -player.direction;
			idlePosition.X += minionPositionOffsetX; // Go behind the player

			// All of this code below this line is adapted from Spazmamini code (ID 388, aiStyle 66)

			// Teleport to player if distance is too big
			Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 2000f) {
				// Whenever you deal with non-regular events that change the behavior or position drastically, make sure to only run the code on the owner of the projectile,
				// and then set netUpdate to true
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}

			// If your minion is flying, you want to do this independently of any conditions
			float overlapVelocity = 0.04f;
			for (int i = 0; i < Main.maxProjectiles; i++) {
				// Fix overlap with other minions
				Projectile other = Main.projectile[i];
				if (i != projectile.whoAmI && other.active && other.owner == projectile.owner && Math.Abs(projectile.position.X - other.position.X) + Math.Abs(projectile.position.Y - other.position.Y) < projectile.width) {
					if (projectile.position.X < other.position.X) projectile.velocity.X -= overlapVelocity;
					else projectile.velocity.X += overlapVelocity;

					if (projectile.position.Y < other.position.Y) projectile.velocity.Y -= overlapVelocity;
					else projectile.velocity.Y += overlapVelocity;
				}
			}
			#endregion

			#region Find target
			// Starting search distance
			float distanceFromTarget = 700f;
			Vector2 targetCenter = projectile.position;
			bool foundTarget = false;

			// This code is required if your minion weapon has the targeting feature
			if (player.HasMinionAttackTargetNPC) {
				NPC npc = Main.npc[player.MinionAttackTargetNPC];
				float between = Vector2.Distance(npc.Center, projectile.Center);
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
						float between = Vector2.Distance(npc.Center, projectile.Center);
						bool closest = Vector2.Distance(projectile.Center, targetCenter) > between;
						bool inRange = between < distanceFromTarget;
						bool lineOfSight = Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height);
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
			projectile.friendly = foundTarget;
			#endregion

			#region Movement

			// Default movement parameters (here for attacking)
			float speed = 8f;
			float inertia = 20f;

			if (foundTarget) {
				// Minion has a target: attack (here, fly towards the enemy)
				if (distanceFromTarget > 40f) {
					// The immediate range around the target (so it doesn't latch onto it when close)
					Vector2 direction = targetCenter - projectile.Center;
					direction.Normalize();
					direction *= speed;
					projectile.velocity = (projectile.velocity * (inertia - 1) + direction) / inertia;
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
					projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
				}
				else if (projectile.velocity == Vector2.Zero) {
					// If there is a case where it's not moving at all, give it a little "poke"
					projectile.velocity.X = -0.15f;
					projectile.velocity.Y = -0.05f;
				}
			}
			projectile.velocity = Collision.TileCollision(projectile.position, projectile.velocity, projectile.width, projectile.height);
			Collision.StepUp(ref projectile.position, ref projectile.velocity, projectile.width, projectile.height, ref projectile.stepSpeed, ref projectile.gfxOffY);
			#endregion

			#region Animation and visuals
			// So it will lean slightly towards the direction it's moving
			projectile.rotation = projectile.velocity.X * 0.05f;
			#endregion
		}
		
		public void AIWalker()
		{
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			
			////////
			//IDLE//
			////////
			Vector2 idlePosition = player.Center;
			float minionPositionOffsetX = (projectile.width + projectile.minionPos * projectile.width) * -player.direction;
			idlePosition.X += minionPositionOffsetX; // Go behind the player
			Vector2 moveToPosition = idlePosition;

			int targetID = -1;
			float searchDist = 700f;
			
			int num830 = 15;
			if (projectile.ai[0] == 0f)
			{
				NPC thisTarget = projectile.OwnerMinionAttackTargetNPC;
				if (thisTarget != null && thisTarget.CanBeChasedBy(this))
				{
					float distanceTargetToProjectile = (thisTarget.Center - projectile.Center).Length();
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
							float distanceProjectileToNPC = (thisNPC.Center - projectile.Center).Length();
							if (distanceProjectileToNPC < searchDist)
							{
								targetID = i;
								searchDist = distanceProjectileToNPC;
							}
						}
					}
				}
				projectile.friendly = targetID != -1;
			}
			if (projectile.ai[0] == 1f)
			{
				projectile.tileCollide = false;
				float num834 = 0.2f;
				float num835 = 10f;
				int maxDist = 200;
				if (num835 < Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y))
				{
					num835 = Math.Abs(player.velocity.X) + Math.Abs(player.velocity.Y);
				}
				Vector2 distancePlayerToProjectile = player.Center - projectile.Center;
				float lengthPlayerToProjectile = distancePlayerToProjectile.Length();
				
				//Jump to player if projectile is way too far away
				if (lengthPlayerToProjectile > 2000f)
				{
					projectile.position = player.Center - new Vector2(projectile.width, projectile.height) / 2f;
				}
				
				if (lengthPlayerToProjectile < (float)maxDist && player.velocity.Y == 0f && projectile.position.Y + (float)projectile.height <= player.position.Y + (float)player.height && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
				{
					projectile.ai[0] = 0f;
					projectile.netUpdate = true;
					if (projectile.velocity.Y < -6f)
					{
						projectile.velocity.Y = -6f;
					}
				}
				
				//Rocket Back to player
				if (!(lengthPlayerToProjectile < 60f))
				{
					distancePlayerToProjectile.Normalize();
					distancePlayerToProjectile *= num835;
					if (projectile.velocity.X < distancePlayerToProjectile.X)
					{
						projectile.velocity.X += num834;
						if (projectile.velocity.X < 0f)
						{
							projectile.velocity.X += num834 * 1.5f;
						}
					}
					if (projectile.velocity.X > distancePlayerToProjectile.X)
					{
						projectile.velocity.X -= num834;
						if (projectile.velocity.X > 0f)
						{
							projectile.velocity.X -= num834 * 1.5f;
						}
					}
					if (projectile.velocity.Y < distancePlayerToProjectile.Y)
					{
						projectile.velocity.Y += num834;
						if (projectile.velocity.Y < 0f)
						{
							projectile.velocity.Y += num834 * 1.5f;
						}
					}
					if (projectile.velocity.Y > distancePlayerToProjectile.Y)
					{
						projectile.velocity.Y -= num834;
						if (projectile.velocity.Y > 0f)
						{
							projectile.velocity.Y -= num834 * 1.5f;
						}
					}
				}
				if (projectile.velocity.X != 0f)
				{
					projectile.spriteDirection = Math.Sign(projectile.velocity.X);
				}
				projectile.rotation = projectile.velocity.X * 0.1f;
			}
			
			//Seems to handle some sort of timer
			if (projectile.ai[0] == 2f)
			{
				projectile.friendly = true;
				projectile.spriteDirection = projectile.direction;
				projectile.rotation = 0f;
				projectile.velocity.Y += 0.4f;
				if (projectile.velocity.Y > 10f)
				{
					projectile.velocity.Y = 10f;
				}
				projectile.ai[1]--;
				if (projectile.ai[1] <= 0f)
				{
					projectile.ai[1] = 0f;
					projectile.ai[0] = 0f;
					projectile.friendly = false;
					projectile.netUpdate = true;
					return;
				}
			}
			if (targetID >= 0)
			{
				float num839 = 400f;
				float num840 = 20f;
				num839 = 700f;
				if ((double)projectile.position.Y > Main.worldSurface * 16.0)
				{
					num839 *= 0.7f;
				}
				NPC target = Main.npc[targetID];
				Vector2 targetCenter = target.Center;
				float num841 = (targetCenter - projectile.Center).Length();
				bool flag21 = Collision.CanHit(projectile.position, projectile.width, projectile.height, target.position, target.width, target.height);
				if (num841 < num839)
				{
					moveToPosition = targetCenter;
					
					//Alter Jumps based on height
					if (targetCenter.Y < projectile.Center.Y - 30f && projectile.velocity.Y == 0f)
					{
						float distanceTargetToProjectile = Math.Abs(targetCenter.Y - projectile.Center.Y);
						if (distanceTargetToProjectile < 120f)
						{
							projectile.velocity.Y = -10f;
						}
						else if (distanceTargetToProjectile < 210f)
						{
							projectile.velocity.Y = -13f;
						}
						else if (distanceTargetToProjectile < 270f)
						{
							projectile.velocity.Y = -15f;
						}
						else if (distanceTargetToProjectile < 310f)
						{
							projectile.velocity.Y = -17f;
						}
						else if (distanceTargetToProjectile < 380f)
						{
							projectile.velocity.Y = -18f;
						}
					}//*/
				}
				if (num841 < num840)
				{
					projectile.ai[0] = 2f;
					projectile.ai[1] = num830;
					projectile.netUpdate = true;
				}
			}
			if (projectile.ai[0] == 0f && targetID < 0)
			{
				float num843 = 500f;
				if (Main.player[projectile.owner].rocketDelay2 > 0)
				{
					projectile.ai[0] = 1f;
					projectile.netUpdate = true;
				}
				Vector2 vector68 = player.Center - projectile.Center;
				if (vector68.Length() > 2000f)
				{
					projectile.position = player.Center - new Vector2(projectile.width, projectile.height) / 2f;
				}
				else if (vector68.Length() > num843 || Math.Abs(vector68.Y) > 300f)
				{
					projectile.ai[0] = 1f;
					projectile.netUpdate = true;
					if (projectile.velocity.Y > 0f && vector68.Y < 0f)
					{
						projectile.velocity.Y = 0f;
					}
					if (projectile.velocity.Y < 0f && vector68.Y > 0f)
					{
						projectile.velocity.Y = 0f;
					}
				}
			}
			if (projectile.ai[0] == 0f)
			{
				projectile.tileCollide = true;
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
				float distanceMovePositionToProjectile = moveToPosition.X - projectile.Center.X;
				
				//Movement Control?
				if (Math.Abs(distanceMovePositionToProjectile) > 5f)
				{
					if (distanceMovePositionToProjectile < 0f)
					{
						num849 = -1;
						if (projectile.velocity.X > 0f - num845)
						{
							projectile.velocity.X -= num844;
						}
						else
						{
							projectile.velocity.X -= num847;
						}
					}
					else
					{
						num849 = 1;
						if (projectile.velocity.X < num845)
						{
							projectile.velocity.X += num844;
						}
						else
						{
							projectile.velocity.X += num847;
						}
					}
					flag22 = true;
				}
				
				//Slow Down Movement
				else
				{
					projectile.velocity.X *= 0.9f;
					if (Math.Abs(projectile.velocity.X) < num844 * 2f)
					{
						projectile.velocity.X = 0f;
					}
				}
				if (num849 != 0)
				{
					int num851 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
					int num852 = (int)projectile.position.Y / 16;
					num851 += num849;
					num851 += (int)projectile.velocity.X;
					for (int i = num852; i < num852 + projectile.height / 16 + 1; i++)
					{
						if (WorldGen.SolidTile(num851, i))
						{
							flag22 = true;
						}
					}
				}
				Collision.StepUp(ref projectile.position, ref projectile.velocity, projectile.width, projectile.height, ref projectile.stepSpeed, ref projectile.gfxOffY);
				if (projectile.velocity.Y == 0f && flag22)
				{
					for (int i = 0; i < 3; i++)
					{
						int tileX = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
						if (i == 0)
						{
							tileX = (int)projectile.position.X / 16;
						}
						if (i == 2)
						{
							tileX = (int)(projectile.position.X + (float)projectile.width) / 16;
						}
						int tileY = (int)(projectile.position.Y + (float)projectile.height) / 16;
						if (!WorldGen.SolidTile(tileX, tileY) && !Main.tile[tileX, tileY].halfBrick() && Main.tile[tileX, tileY].slope() <= 0 && (!TileID.Sets.Platforms[Main.tile[tileX, tileY].type] || !Main.tile[tileX, tileY].active() || Main.tile[tileX, tileY].inActive()))
						{
							continue;
						}
						try
						{
							tileX = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
							tileY = (int)(projectile.position.Y + (float)(projectile.height / 2)) / 16;
							tileX += num849;
							tileX += (int)projectile.velocity.X;
							if (!WorldGen.SolidTile(tileX, tileY - 1) && !WorldGen.SolidTile(tileX, tileY - 2))
							{
								//dummy code so that pokemon don't keep hopping around??
							}
							else if (!WorldGen.SolidTile(tileX, tileY - 2))
							{
								projectile.velocity.Y = -7.1f;
							}
							else if (WorldGen.SolidTile(tileX, tileY - 5))
							{
								projectile.velocity.Y = -11.1f;
							}
							else if (WorldGen.SolidTile(tileX, tileY - 4))
							{
								projectile.velocity.Y = -10.1f;
							}
							else
							{
								projectile.velocity.Y = -9.1f;
							}//*/
						}
						catch
						{
							projectile.velocity.Y = -9.1f;
						}
					}
				}
				if (projectile.velocity.X > num846)
				{
					projectile.velocity.X = num846;
				}
				
				projectile.spriteDirection = projectile.direction;
				projectile.rotation = 0f;
				projectile.velocity.Y += 0.4f;
				if (projectile.velocity.Y > 10f)
				{
					projectile.velocity.Y = 10f;
				}
			}
		}
	}	
}