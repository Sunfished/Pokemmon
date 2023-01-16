using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items
{
	public class ItemFPheromone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("F Pheromone");
			Tooltip.SetDefault("Evolves Female Pokemon");
		}
		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 19;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = ItemUseStyleID.HoldUp;//Like Fallen Star
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item4;//Like Fallen Star
            Item.maxStack = 999;
			Item.value = 100000;
		}
		
		
	}
}
