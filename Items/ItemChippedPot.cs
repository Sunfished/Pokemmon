using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemChippedPot : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chipped Pot");
			Tooltip.SetDefault("Evolves Antique Sinistea");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 18;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 4;//Like Fallen Star
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item4;//Like Fallen Star
            item.maxStack = 999;
			item.value = 300000;
		}
	}
}
