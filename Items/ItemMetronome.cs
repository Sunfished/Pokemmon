using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemMetronome : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Metronome");
			Tooltip.SetDefault("Evolves Inkay");
		}
		public override void SetDefaults()
		{
			item.width = 15;
			item.height = 20;
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
