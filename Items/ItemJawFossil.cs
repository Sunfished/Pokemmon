using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemJawFossil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jaw Fossil");
			Tooltip.SetDefault("Revives into Tyrunt");
		}
		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 25;
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
