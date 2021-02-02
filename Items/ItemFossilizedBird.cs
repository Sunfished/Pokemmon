using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemFossilizedBird : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fossilized Bird");
			Tooltip.SetDefault("Combine with another Fossilized Half");
		}
		public override void SetDefaults()
		{
			item.width = 23;
			item.height = 23;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 4;//Like Fallen Star
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item4;//Like Fallen Star
            item.maxStack = 999;
			item.value = 100000;
		}
		
		
	}
}
