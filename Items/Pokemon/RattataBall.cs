using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items.Pokemon
{
	//imported from my tAPI mod because I'm lazy
	public class RattataBall : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Rattata's Pokeball");
			//Tooltip.SetDefault("");
			
		}

		public override void SetDefaults() {
			item.damage = 9;
			item.summon = true;
			item.mana = 1;
			item.width = 18;
			item.height = 18;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 4;
			item.noMelee = true;
			item.knockBack = 0;
			item.value = 100000;
			item.rare = 0;
			item.UseSound = SoundID.Item4;
			item.shoot = mod.ProjectileType("Rattata");
			item.shootSpeed = 10f;
			item.buffType = mod.BuffType("BuffRattata"); //The buff added to player after used the item
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
			ModRecipe recipe0 = new ModRecipe(mod);
			recipe0.AddIngredient(this);
			recipe0.AddIngredient(mod.GetItem("ItemRareCandy"),20);
			recipe0.SetResult(mod.ItemType("RattataBall"));
			recipe0.AddTile(mod.TileType("EvolutionMachine"));
			recipe0.AddRecipe();


		}
	}
}