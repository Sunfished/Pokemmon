using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemExpCandyXS : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Exp Candy XS");
			Tooltip.SetDefault("Candy for Growing Pokemon");
		}
		public override void SetDefaults()
		{
			item.width = 11;
			item.height = 11;
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
			recipe0.AddIngredient(ItemID.IronOre,1);
			recipe0.AddTile(TileID.WorkBenches);
			recipe0.SetResult(this);
			recipe0.AddRecipe();

			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(ItemID.FallenStar,1);
			recipe1.AddIngredient(ItemID.LeadOre,1);
			recipe1.AddTile(TileID.WorkBenches);
			recipe1.SetResult(this);
			recipe1.AddRecipe();

		}
	}
}
