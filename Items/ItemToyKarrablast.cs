using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemToyKarrablast : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Toy Karrablast");
			Tooltip.SetDefault("Evolves Shelmet");
		}
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 17;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 4;//Like Fallen Star
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item4;//Like Fallen Star
            item.maxStack = 999;
			item.value = 150000;
		}
	}
}
