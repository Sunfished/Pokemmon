using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemWishingStar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wishing Star");
			Tooltip.SetDefault("Evolves Pokemon that love Galar");
		}
		public override void SetDefaults()
		{
			Item.width = 21;
			Item.height = 21;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.HoldUp;//Like Fallen Star
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item4;//Like Fallen Star
            Item.maxStack = 999;
			Item.value = 120000;
		}
		
		
	}
}
