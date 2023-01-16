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
			Item.width = 32;
			Item.height = 25;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 150000;
			Item.createTile = Mod.Find<ModTile>("EvolutionMachine").Type;
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