using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Pokemmon.Items.PokeBoxes
{
	public class BeastBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("BeastBox");
			Tooltip.SetDefault("Contains an Ultra Beast");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.useTime = 10;
			item.useAnimation = 10;
			//item.useStyle = 4;//Like Fallen Star
			item.value = 1000000;
			item.rare = 2;
			item.UseSound = SoundID.Item4;//Like Fallen Star
            item.stack = 1;
			item.maxStack = 999;
			item.consumable = true;
		}

		/*public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}//*/
		
		public override bool CanRightClick() {
			return true;
		}
		
        public override void RightClick(Player player)
        {
            int choice = Main.rand.Next(10);
			if(choice==0) {player.QuickSpawnItem(mod.ItemType("NihilegoBall"));}
			if(choice==1) {player.QuickSpawnItem(mod.ItemType("BuzzwoleBall"));}
			if(choice==2) {player.QuickSpawnItem(mod.ItemType("PheromosaBall"));}
			if(choice==3) {player.QuickSpawnItem(mod.ItemType("XurkitreeBall"));}
			if(choice==4) {player.QuickSpawnItem(mod.ItemType("CelesteelaBall"));}
			if(choice==5) {player.QuickSpawnItem(mod.ItemType("KartanaBall"));}
			if(choice==6) {player.QuickSpawnItem(mod.ItemType("GuzzlordBall"));}
			if(choice==7) {player.QuickSpawnItem(mod.ItemType("PoipoleBall"));}
			if(choice==8) {player.QuickSpawnItem(mod.ItemType("StakatakaBall"));}
			if(choice==9) {player.QuickSpawnItem(mod.ItemType("BlacephalonBall"));}

        }
	}
}
