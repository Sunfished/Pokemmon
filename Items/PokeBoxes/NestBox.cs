using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Pokemmon.Items.PokeBoxes
{
	public class NestBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("NestBox");
			Tooltip.SetDefault("Contains a Baby Pokemon");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.useTime = 10;
			item.useAnimation = 10;
			//item.useStyle = 4;//Like Fallen Star
			item.value = 100000;
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
            int choice = Main.rand.Next(18);
			if(choice==0) {player.QuickSpawnItem(mod.ItemType("PichuBall"));}
			if(choice==1) {player.QuickSpawnItem(mod.ItemType("CleffaBall"));}
			if(choice==2) {player.QuickSpawnItem(mod.ItemType("IgglybuffBall"));}
			if(choice==3) {player.QuickSpawnItem(mod.ItemType("TogepiBall"));}
			if(choice==4) {player.QuickSpawnItem(mod.ItemType("TyrogueBall"));}
			if(choice==5) {player.QuickSpawnItem(mod.ItemType("SmoochumBall"));}
			if(choice==6) {player.QuickSpawnItem(mod.ItemType("ElekidBall"));}
			if(choice==7) {player.QuickSpawnItem(mod.ItemType("MagbyBall"));}
			if(choice==8) {player.QuickSpawnItem(mod.ItemType("AzurillBall"));}
			if(choice==9) {player.QuickSpawnItem(mod.ItemType("WynautBall"));}
			if(choice==10) {player.QuickSpawnItem(mod.ItemType("BudewBall"));}
			if(choice==11) {player.QuickSpawnItem(mod.ItemType("ChinglingBall"));}
			if(choice==12) {player.QuickSpawnItem(mod.ItemType("BonslyBall"));}
			if(choice==13) {player.QuickSpawnItem(mod.ItemType("MimeJrBall"));}
			if(choice==14) {player.QuickSpawnItem(mod.ItemType("HappinyBall"));}
			if(choice==15) {player.QuickSpawnItem(mod.ItemType("RioluBall"));}
			if(choice==16) {player.QuickSpawnItem(mod.ItemType("MantykeBall"));}
			if(choice==17) {player.QuickSpawnItem(mod.ItemType("ToxelBall"));}

        }
	}
}
