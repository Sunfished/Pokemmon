using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemExpCandyM : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Exp Candy M");
			Tooltip.SetDefault("Candy for Good Pokemon");
		}
		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 15;
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
			recipe0.AddIngredient(ItemID.CobaltOre,1);
			recipe0.AddTile(TileID.WorkBenches);
			recipe0.Register();

			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.FallenStar,1);
			recipe1.AddIngredient(ItemID.PalladiumOre,1);
			recipe1.AddTile(TileID.WorkBenches);
			recipe1.Register();

		}
	}
}
