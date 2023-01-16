using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Pokemmon.Buffs;
using static Terraria.ModLoader.ModContent;

namespace Pokemmon.Projectiles.Minions
{
	public class SilvallySteel : PokemmonMinion
	{
		public override void SetDefaults()
		{
			myBuffID = ModContent.BuffType<BuffSilvallySteel>();
			steelType=true;
			
			
			Projectile.netImportant = true;

			Projectile.width = 52;
			Projectile.height = 56;
			Main.projFrames[Projectile.type] = 1;
			Projectile.timeLeft = 18000;
			//projectile.ignoreWater = true;
            Projectile.tileCollide = false;
			
			// Only controls if it deals damage to enemies on contact (more on that later)
			Projectile.friendly = true;
			// Only determines the damage type
			Projectile.minion = true;
			// Amount of slots this minion occupies from the total minion slots available to the player (more on that later)
			Projectile.minionSlots = 1f;
			// Needed so the minion doesn't despawn on collision with enemies or tiles
			Projectile.penetrate = -1;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Silvally");
			// Denotes that this projectile is a pet or minion
			Main.projPet[Projectile.type] = true;
			// This is needed so your minion can properly spawn when summoned and replaced when other minions are summoned
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			// Don't mistake this with "if this is true, then it will automatically home". It is just for damage reduction for certain NPCs
			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
		}
	}
}