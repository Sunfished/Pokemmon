using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemSailFossil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sail Fossil");
			Tooltip.SetDefault("Revives into Amaura");
		}
		public override void SetDefaults()
		{
			item.width = 25;
			item.height = 24;
			item.useTime = 10;
			item.useAnimation = 10;
			item.useStyle = 4;//Like Fallen Star
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item4;//Like Fallen Star
            item.maxStack = 999;
			item.value = 50000;
		}
		
		
	}
}
