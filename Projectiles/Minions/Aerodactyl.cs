using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace Pokemmon.Projectiles.Minions
{
	public class Aerodactyl : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.CloneDefaults(394);
			aiType = 394;

			projectile.width = 58;
			projectile.height = 40;
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
			DisplayName.SetDefault("Aerodactyl");
		}

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
			//#region Active check
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = (MyPlayer)player.GetModPlayer(mod, "MyPlayer");
			
			if (player.dead || !player.active)
			{
				modPlayer.summonedAerodactyl = false;
				//player.ClearBuff{BuffType<BuffAerodactyl>());
			}
				
			if (modPlayer.summonedAerodactyl == true)//(player.HasBuff(BuffType<BuffAerodactyl>()))
			{
				projectile.timeLeft = 2;
			}
			//#endregion
		}
	}
}