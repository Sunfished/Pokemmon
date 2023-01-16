using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemWhippedDream : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Whipped Dream");
			Tooltip.SetDefault("Evolves Swirlix");
		}
		public override void SetDefaults()
		{
			Item.width = 19;
			Item.height = 21;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.HoldUp;//Like Fallen Star
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item4;//Like Fallen Star
            Item.maxStack = 999;
			Item.value = 150000;
		}
		
		
	}
}
