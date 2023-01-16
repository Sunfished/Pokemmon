using Terraria;
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
			Item.width = 21;
			Item.height = 20;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.HoldUp;//Like Fallen Star
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item4;//Like Fallen Star
            Item.maxStack = 999;
			Item.value = 1;
		}
		
		public override void AddRecipes() {
			Recipe recipe0 = CreateRecipe();
			recipe0.AddIngredient(ItemID.FallenStar,1);
			recipe0.AddIngredient(ItemID.FragmentSolar,1);
			recipe0.AddTile(TileID.WorkBenches);
			recipe0.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.FallenStar,1);
			recipe1.AddIngredient(ItemID.FragmentVortex,1);
			recipe1.AddTile(TileID.WorkBenches);
			recipe1.Register();

			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.FallenStar,1);
			recipe2.AddIngredient(ItemID.FragmentNebula,1);
			recipe2.AddTile(TileID.WorkBenches);
			recipe2.Register();

			Recipe recipe3 = CreateRecipe();
			recipe3.AddIngredient(ItemID.FallenStar,1);
			recipe3.AddIngredient(ItemID.FragmentStardust,1);
			recipe3.AddTile(TileID.WorkBenches);
			recipe3.Register();

		}
	}
}
