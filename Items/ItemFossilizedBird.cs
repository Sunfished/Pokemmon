using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemFossilizedBird : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fossilized Bird");
			Tooltip.SetDefault("Combine with another Fossilized Half");
		}
		public override void SetDefaults()
		{
			Item.width = 23;
			Item.height = 23;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.HoldUp;//Like Fallen Star
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item4;//Like Fallen Star
            Item.maxStack = 999;
			Item.value = 100000;
		}
		
		
	}
}