using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items.Placeable
{
	public class EvolutionMachine : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Evolution Machine");
			Tooltip.SetDefault("Used to Evolve Pokemon");
		}

		public override void SetDefaults() {
			item.width = 32;
			item.height = 25;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("EvolutionMachine");
		}

		/*public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.WorkBench);
			recipe.AddIngredient(mod.ItemType("ExampleBlock"), 10);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}//*/
	}
}