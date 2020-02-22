using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items.Pokemon
{
	//imported from my tAPI mod because I'm lazy
	public class ArceusDarkBall : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Arceus's Pokeball");
			//Tooltip.SetDefault("");
			Tooltip.SetDefault("Dark Forme");
		}

		public override void SetDefaults() {
			item.damage = 53;
			item.summon = true;
			item.mana = 1;
			item.width = 18;
			item.height = 18;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 4;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 300000;
			item.rare = 10;
			item.UseSound = SoundID.Item4;
			item.shoot = mod.ProjectileType("ArceusDark");
			item.shootSpeed = 10f;
			item.buffType = mod.BuffType("BuffArceusDark"); //The buff added to player after used the item
			item.buffTime = 3600;               //The duration of the buff, here is 60 seconds
			item.stack = 1;
			item.maxStack = 999;
		}

		public override bool AltFunctionUse(Player player) {
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			return player.altFunctionUse != 2;
		}

		public override bool UseItem(Player player) {
			if (player.altFunctionUse == 2) {
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}
		
		public override void AddRecipes()
		{

		}
	}
}