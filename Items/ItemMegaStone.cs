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
			item.width = 14;
			item.height = 14;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 4;//Like Fallen Star
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item4;//Like Fallen Star
            item.maxStack = 999;
			item.value = 1000000;
		}
		
		
	}
}
