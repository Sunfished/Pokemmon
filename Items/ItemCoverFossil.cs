using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemCoverFossil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cover Fossil");
			Tooltip.SetDefault("Revives into Tirtouga");
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
			Item.value = 50000;
		}
		
		
	}
}
