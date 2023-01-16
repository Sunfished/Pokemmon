using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemSailFossil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sail Fossil");
			Tooltip.SetDefault("Revives into Amaura");
		}
		public override void SetDefaults()
		{
			Item.width = 25;
			Item.height = 24;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.HoldUp;//Like Fallen Star
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item4;//Like Fallen Star
            Item.maxStack = 999;
			Item.value = 50000;
		}
		
		
	}
}
