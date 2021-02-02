using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items.Pokemon
{
	//imported from my tAPI mod because I'm lazy
	public class EeveeBall : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Eevee's Pokeball");
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
			item.rare = 8;
			item.UseSound = SoundID.Item4;
			item.shoot = mod.ProjectileType("Eevee");
			item.shootSpeed = 10f;
			item.buffType = mod.BuffType("BuffEevee"); //The buff added to player after used the item
			item.buffTime = 3600;               //The duration of the buff, here is 60 seconds
			item.stack = 1;
			item.maxStack = 999;
		}

		public override bool AltFunctionUse(Player player) {
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			modPlayer.ResetEffects();
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
			recipe0.AddIngredient(mod.GetItem("ItemWaterStone"),1);
			recipe0.AddIngredient(mod.GetItem("ItemExpCandyL"),1);
			recipe0.SetResult(mod.ItemType("VaporeonBall"));
			recipe0.AddTile(mod.TileType("EvolutionMachine"));
			recipe0.AddRecipe();

			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(this);
			recipe1.AddIngredient(mod.GetItem("ItemThunderStone"),1);
			recipe1.AddIngredient(mod.GetItem("ItemExpCandyL"),1);
			recipe1.SetResult(mod.ItemType("JolteonBall"));
			recipe1.AddTile(mod.TileType("EvolutionMachine"));
			recipe1.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(this);
			recipe2.AddIngredient(mod.GetItem("ItemFireStone"),1);
			recipe2.AddIngredient(mod.GetItem("ItemExpCandyL"),1);
			recipe2.SetResult(mod.ItemType("FlareonBall"));
			recipe2.AddTile(mod.TileType("EvolutionMachine"));
			recipe2.AddRecipe();

			ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(this);
			recipe3.AddIngredient(mod.GetItem("ItemSunStone"),1);
			recipe3.AddIngredient(mod.GetItem("ItemExpCandyL"),1);
			recipe3.SetResult(mod.ItemType("EspeonBall"));
			recipe3.AddTile(mod.TileType("EvolutionMachine"));
			recipe3.AddRecipe();

			ModRecipe recipe4 = new ModRecipe(mod);
			recipe4.AddIngredient(this);
			recipe4.AddIngredient(mod.GetItem("ItemMoonStone"),1);
			recipe4.AddIngredient(mod.GetItem("ItemExpCandyL"),1);
			recipe4.SetResult(mod.ItemType("UmbreonBall"));
			recipe4.AddTile(mod.TileType("EvolutionMachine"));
			recipe4.AddRecipe();

			ModRecipe recipe5 = new ModRecipe(mod);
			recipe5.AddIngredient(this);
			recipe5.AddIngredient(mod.GetItem("ItemIceStone"),1);
			recipe5.AddIngredient(mod.GetItem("ItemExpCandyL"),1);
			recipe5.SetResult(mod.ItemType("GlaceonBall"));
			recipe5.AddTile(mod.TileType("EvolutionMachine"));
			recipe5.AddRecipe();

			ModRecipe recipe6 = new ModRecipe(mod);
			recipe6.AddIngredient(this);
			recipe6.AddIngredient(mod.GetItem("ItemLeafStone"),1);
			recipe6.AddIngredient(mod.GetItem("ItemExpCandyL"),1);
			recipe6.SetResult(mod.ItemType("LeafeonBall"));
			recipe6.AddTile(mod.TileType("EvolutionMachine"));
			recipe6.AddRecipe();

			ModRecipe recipe7 = new ModRecipe(mod);
			recipe7.AddIngredient(this);
			recipe7.AddIngredient(mod.GetItem("ItemSootheBell"),1);
			recipe7.AddIngredient(mod.GetItem("ItemTM"),1);
			recipe7.AddIngredient(mod.GetItem("ItemExpCandyL"),1);
			recipe7.SetResult(mod.ItemType("SylveonBall"));
			recipe7.AddTile(mod.TileType("EvolutionMachine"));
			recipe7.AddRecipe();


		}
	}
}