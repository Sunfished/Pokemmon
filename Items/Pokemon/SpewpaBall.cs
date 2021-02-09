using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items.Pokemon
{
	//imported from my tAPI mod because I'm lazy
	public class SpewpaBall : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Spewpa's Pokeball");
			//Tooltip.SetDefault("");
			
		}

		public override void SetDefaults() {
			item.damage = 6;
			item.summon = true;
			item.mana = 1;
			item.width = 18;
			item.height = 18;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 4;
			item.noMelee = true;
			item.knockBack = 0;
			item.value = 105882;
			item.rare = 5;
			item.UseSound = SoundID.Item4;
			item.shoot = mod.ProjectileType("Spewpa");
			item.shootSpeed = 10f;
			item.buffType = mod.BuffType("BuffSpewpa"); //The buff added to player after used the item
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
			modPlayer.pokemonAmount++;
			//modPlayer.summonedSpewpa = true;
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
			recipe0.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe0.SetResult(mod.ItemType("VivillonMeadowBall"));
			recipe0.AddTile(mod.TileType("EvolutionMachine"));
			recipe0.AddRecipe();

			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(this);
			recipe1.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe1.SetResult(mod.ItemType("VivillonArchipelagoBall"));
			recipe1.AddTile(mod.TileType("EvolutionMachine"));
			recipe1.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(this);
			recipe2.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe2.SetResult(mod.ItemType("VivillonContinentalBall"));
			recipe2.AddTile(mod.TileType("EvolutionMachine"));
			recipe2.AddRecipe();

			ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(this);
			recipe3.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe3.SetResult(mod.ItemType("VivillonElegantBall"));
			recipe3.AddTile(mod.TileType("EvolutionMachine"));
			recipe3.AddRecipe();

			ModRecipe recipe4 = new ModRecipe(mod);
			recipe4.AddIngredient(this);
			recipe4.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe4.SetResult(mod.ItemType("VivillonGardenBall"));
			recipe4.AddTile(mod.TileType("EvolutionMachine"));
			recipe4.AddRecipe();

			ModRecipe recipe5 = new ModRecipe(mod);
			recipe5.AddIngredient(this);
			recipe5.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe5.SetResult(mod.ItemType("VivillonHighPlainsBall"));
			recipe5.AddTile(mod.TileType("EvolutionMachine"));
			recipe5.AddRecipe();

			ModRecipe recipe6 = new ModRecipe(mod);
			recipe6.AddIngredient(this);
			recipe6.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe6.SetResult(mod.ItemType("VivillonIcySnowBall"));
			recipe6.AddTile(mod.TileType("EvolutionMachine"));
			recipe6.AddRecipe();

			ModRecipe recipe7 = new ModRecipe(mod);
			recipe7.AddIngredient(this);
			recipe7.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe7.SetResult(mod.ItemType("VivillonJungleBall"));
			recipe7.AddTile(mod.TileType("EvolutionMachine"));
			recipe7.AddRecipe();

			ModRecipe recipe8 = new ModRecipe(mod);
			recipe8.AddIngredient(this);
			recipe8.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe8.SetResult(mod.ItemType("VivillonMarineBall"));
			recipe8.AddTile(mod.TileType("EvolutionMachine"));
			recipe8.AddRecipe();

			ModRecipe recipe9 = new ModRecipe(mod);
			recipe9.AddIngredient(this);
			recipe9.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe9.SetResult(mod.ItemType("VivillonModernBall"));
			recipe9.AddTile(mod.TileType("EvolutionMachine"));
			recipe9.AddRecipe();

			ModRecipe recipe10 = new ModRecipe(mod);
			recipe10.AddIngredient(this);
			recipe10.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe10.SetResult(mod.ItemType("VivillonMonsoonBall"));
			recipe10.AddTile(mod.TileType("EvolutionMachine"));
			recipe10.AddRecipe();

			ModRecipe recipe11 = new ModRecipe(mod);
			recipe11.AddIngredient(this);
			recipe11.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe11.SetResult(mod.ItemType("VivillonOceanBall"));
			recipe11.AddTile(mod.TileType("EvolutionMachine"));
			recipe11.AddRecipe();

			ModRecipe recipe12 = new ModRecipe(mod);
			recipe12.AddIngredient(this);
			recipe12.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe12.SetResult(mod.ItemType("VivillonPolarBall"));
			recipe12.AddTile(mod.TileType("EvolutionMachine"));
			recipe12.AddRecipe();

			ModRecipe recipe13 = new ModRecipe(mod);
			recipe13.AddIngredient(this);
			recipe13.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe13.SetResult(mod.ItemType("VivillonRiverBall"));
			recipe13.AddTile(mod.TileType("EvolutionMachine"));
			recipe13.AddRecipe();

			ModRecipe recipe14 = new ModRecipe(mod);
			recipe14.AddIngredient(this);
			recipe14.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe14.SetResult(mod.ItemType("VivillonSandstormBall"));
			recipe14.AddTile(mod.TileType("EvolutionMachine"));
			recipe14.AddRecipe();

			ModRecipe recipe15 = new ModRecipe(mod);
			recipe15.AddIngredient(this);
			recipe15.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe15.SetResult(mod.ItemType("VivillonSavannaBall"));
			recipe15.AddTile(mod.TileType("EvolutionMachine"));
			recipe15.AddRecipe();

			ModRecipe recipe16 = new ModRecipe(mod);
			recipe16.AddIngredient(this);
			recipe16.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe16.SetResult(mod.ItemType("VivillonSunBall"));
			recipe16.AddTile(mod.TileType("EvolutionMachine"));
			recipe16.AddRecipe();

			ModRecipe recipe17 = new ModRecipe(mod);
			recipe17.AddIngredient(this);
			recipe17.AddIngredient(mod.GetItem("ItemExpCandyS"),12);
			recipe17.SetResult(mod.ItemType("VivillonTundraBall"));
			recipe17.AddTile(mod.TileType("EvolutionMachine"));
			recipe17.AddRecipe();

			ModRecipe recipe99 = new ModRecipe(mod);
			recipe99.AddIngredient(this);
			recipe99.AddIngredient(mod.GetItem("ItemEverstone"),1);
			recipe99.SetResult(mod.ItemType("ScatterbugBall"));
			recipe99.AddTile(mod.TileType("EvolutionMachine"));
			recipe99.AddRecipe();


		}
	}
}