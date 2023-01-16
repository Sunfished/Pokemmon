using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemMegaStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mega Stone");
			Tooltip.SetDefault("Mega Evolves Pokemon");
		}
		public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 14;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.HoldUp;//Like Fallen Star
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item4;//Like Fallen Star
            Item.maxStack = 999;
			Item.value = 1000000;
		}
		
		
	}
}
