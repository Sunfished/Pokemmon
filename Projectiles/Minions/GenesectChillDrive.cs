using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Pokemmon.Projectiles.Minions
{
	public class GenesectChillDrive : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.CloneDefaults(394);
			aiType = 394;

			projectile.width = 44;
			projectile.height = 44;
			Main.projFrames[projectile.type] = 1;
			projectile.friendly = true;
			projectile.minion = true;
			projectile.minionSlots = 1;
			projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			//projectile.ignoreWater = true;
            projectile.tileCollide = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Genesect");
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}//*/
		
		public override void AI()
		{
			//#region Active check
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
			
			if (player.dead || !player.active)
			{
				modPlayer.summonedGenesectChillDrive = false;
				//player.ClearBuff{BuffType<BuffGenesectChillDrive>());
			}
				
			if (modPlayer.summonedGenesectChillDrive == true)//(player.HasBuff(BuffType<BuffGenesectChillDrive>()))
			{
				projectile.timeLeft = 2;
			}
			//#endregion
		}
	}
}