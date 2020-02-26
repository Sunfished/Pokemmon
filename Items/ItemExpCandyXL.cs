using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemExpCandyXL : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Exp Candy XL");
			Tooltip.SetDefault("Candy for Legendary Pokemon");
		}
		public override void SetDefaults()
		{
			item.width = 21;
			item.height = 20;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 4;//Like Fallen Star
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item4;//Like Fallen Star
            item.maxStack = 999;
			item.value = 1;
		}
		
		public override void AddRecipes() {
			ModRecipe recipe0 = new ModRecipe(mod);
			recipe0.AddIngredient(ItemID.FallenStar,1);
			recipe0.AddIngredient(ItemID.FragmentSolar,1);
			recipe0.AddTile(TileID.WorkBenches);
			recipe0.SetResult(this);
			recipe0.AddRecipe();

			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(ItemID.FallenStar,1);
			recipe1.AddIngredient(ItemID.FragmentVortex,1);
			recipe1.AddTile(TileID.WorkBenches);
			recipe1.SetResult(this);
			recipe1.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.FallenStar,1);
			recipe2.AddIngredient(ItemID.FragmentNebula,1);
			recipe2.AddTile(TileID.WorkBenches);
			recipe2.SetResult(this);
			recipe2.AddRecipe();

			ModRecipe recipe3 = new ModRecipe(mod);
			recipe3.AddIngredient(ItemID.FallenStar,1);
			recipe3.AddIngredient(ItemID.FragmentStardust,1);
			recipe3.AddTile(TileID.WorkBenches);
			recipe3.SetResult(this);
			recipe3.AddRecipe();

		}
	}
}
