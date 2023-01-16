using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemExpCandyS : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Exp Candy S");
			Tooltip.SetDefault("Candy for Training Pokemon");
		}
		public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 14;
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
			recipe0.AddIngredient(ItemID.Bone,1);
			recipe0.AddTile(TileID.WorkBenches);
			recipe0.Register();

		}
	}
}
