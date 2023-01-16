using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemPlumeFossil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Plume Fossil");
			Tooltip.SetDefault("Revives into Archen");
		}
		public override void SetDefaults()
		{
			Item.width = 19;
			Item.height = 18;
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
