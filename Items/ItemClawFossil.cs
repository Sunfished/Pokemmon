using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemClawFossil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Claw Fossil");
			Tooltip.SetDefault("Revives into Anorith");
		}
		public override void SetDefaults()
		{
			item.width = 21;
			item.height = 19;
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
