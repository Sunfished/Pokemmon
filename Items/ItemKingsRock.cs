using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemKingsRock : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("King's Rock");
			Tooltip.SetDefault("Evolves certain Pokemon");
		}
		public override void SetDefaults()
		{
			item.width = 21;
			item.height = 22;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 4;//Like Fallen Star
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item4;//Like Fallen Star
            item.maxStack = 999;
			item.value = 120000;
		}
	}
}
