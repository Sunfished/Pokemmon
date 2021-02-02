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
			item.width = 19;
			item.height = 18;
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
