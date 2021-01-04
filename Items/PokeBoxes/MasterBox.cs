using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Pokemmon.Items.PokeBoxes
{
	public class MasterBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("MasterBox");
			Tooltip.SetDefault("Contains a Legendary Pokemon");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.useTime = 10;
			item.useAnimation = 10;
			//item.useStyle = 4;//Like Fallen Star
			item.value = 1500000;
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
            int choice = Main.rand.Next(41);
			if(choice==0) {player.QuickSpawnItem(mod.ItemType("ArticunoBall"));}
			if(choice==1) {player.QuickSpawnItem(mod.ItemType("ZapdosBall"));}
			if(choice==2) {player.QuickSpawnItem(mod.ItemType("MoltresBall"));}
			if(choice==3) {player.QuickSpawnItem(mod.ItemType("MewtwoBall"));}
			if(choice==4) {player.QuickSpawnItem(mod.ItemType("RaikouBall"));}
			if(choice==5) {player.QuickSpawnItem(mod.ItemType("EnteiBall"));}
			if(choice==6) {player.QuickSpawnItem(mod.ItemType("SuicuneBall"));}
			if(choice==7) {player.QuickSpawnItem(mod.ItemType("LugiaBall"));}
			if(choice==8) {player.QuickSpawnItem(mod.ItemType("HoohBall"));}
			if(choice==9) {player.QuickSpawnItem(mod.ItemType("RegirockBall"));}
			if(choice==10) {player.QuickSpawnItem(mod.ItemType("RegiceBall"));}
			if(choice==11) {player.QuickSpawnItem(mod.ItemType("RegisteelBall"));}
			if(choice==12) {player.QuickSpawnItem(mod.ItemType("LatiasBall"));}
			if(choice==13) {player.QuickSpawnItem(mod.ItemType("KyogreBall"));}
			if(choice==14) {player.QuickSpawnItem(mod.ItemType("GroudonBall"));}
			if(choice==15) {player.QuickSpawnItem(mod.ItemType("RayquazaBall"));}
			if(choice==16) {player.QuickSpawnItem(mod.ItemType("UxieBall"));}
			if(choice==17) {player.QuickSpawnItem(mod.ItemType("MespritBall"));}
			if(choice==18) {player.QuickSpawnItem(mod.ItemType("AzelfBall"));}
			if(choice==19) {player.QuickSpawnItem(mod.ItemType("DialgaBall"));}
			if(choice==20) {player.QuickSpawnItem(mod.ItemType("PalkiaBall"));}
			if(choice==21) {player.QuickSpawnItem(mod.ItemType("HeatranBall"));}
			if(choice==22) {player.QuickSpawnItem(mod.ItemType("RegigigasBall"));}
			if(choice==23) {player.QuickSpawnItem(mod.ItemType("GiratinaBall"));}
			if(choice==24) {player.QuickSpawnItem(mod.ItemType("CresseliaBall"));}
			if(choice==25) {player.QuickSpawnItem(mod.ItemType("CobalionBall"));}
			if(choice==26) {player.QuickSpawnItem(mod.ItemType("TerrakionBall"));}
			if(choice==27) {player.QuickSpawnItem(mod.ItemType("VirizionBall"));}
			if(choice==28) {player.QuickSpawnItem(mod.ItemType("TornadusBall"));}
			if(choice==29) {player.QuickSpawnItem(mod.ItemType("ThundurusBall"));}
			if(choice==30) {player.QuickSpawnItem(mod.ItemType("ReshiramBall"));}
			if(choice==31) {player.QuickSpawnItem(mod.ItemType("ZekromBall"));}
			if(choice==32) {player.QuickSpawnItem(mod.ItemType("LandorusBall"));}
			if(choice==33) {player.QuickSpawnItem(mod.ItemType("KyuremBall"));}
			if(choice==34) {player.QuickSpawnItem(mod.ItemType("XerneasBall"));}
			if(choice==35) {player.QuickSpawnItem(mod.ItemType("YveltalBall"));}
			if(choice==36) {player.QuickSpawnItem(mod.ItemType("CosmogBall"));}
			if(choice==37) {player.QuickSpawnItem(mod.ItemType("NecrozmaBall"));}
			if(choice==38) {player.QuickSpawnItem(mod.ItemType("ZacianBall"));}
			if(choice==39) {player.QuickSpawnItem(mod.ItemType("ZamazentaBall"));}
			if(choice==40) {player.QuickSpawnItem(mod.ItemType("EternatusBall"));}

        }
	}
}
