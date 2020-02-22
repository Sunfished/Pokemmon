using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemShinyStone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shiny Stone");
			Tooltip.SetDefault("Evolves certain Pokemon");
		}
		public override void SetDefaults()
		{
			item.width = 19;
			item.height = 19;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 4;//Like Fallen Star
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item4;//Like Fallen Star
            item.maxStack = 999;
			item.value = 70000;
		}
	}
}
