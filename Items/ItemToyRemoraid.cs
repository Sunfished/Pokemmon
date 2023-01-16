using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemToyRemoraid : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Toy Remoraid");
			Tooltip.SetDefault("Evolves Mantyke");
		}
		public override void SetDefaults()
		{
			Item.width = 17;
			Item.height = 16;
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
