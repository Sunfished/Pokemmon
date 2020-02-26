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
			item.width = 16;
			item.height = 14;
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
			recipe0.AddIngredient(ItemID.Bone,1);
			recipe0.AddTile(TileID.WorkBenches);
			recipe0.SetResult(this);
			recipe0.AddRecipe();

		}
	}
}
