using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemJawFossil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Jaw Fossil");
			Tooltip.SetDefault("Revives into Tyrunt");
		}
		public override void SetDefaults()
		{
			item.width = 24;
			item.height = 25;
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
