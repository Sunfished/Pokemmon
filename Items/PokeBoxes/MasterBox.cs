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
			Item.width = 22;
			Item.height = 22;
			Item.useTime = 10;
			Item.useAnimation = 10;
			//Item.useStyle = ItemUseStyleID.HoldUp;//Like Fallen Star
			Item.value = 1500000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item4;//Like Fallen Star
            Item.stack = 1;
			Item.maxStack = 999;
			Item.consumable = true;
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
			if(choice==0) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ArticunoBall").Type), Mod.Find<ModItem>("ArticunoBall").Type);}
			if(choice==1) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ZapdosBall").Type), Mod.Find<ModItem>("ZapdosBall").Type);}
			if(choice==2) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MoltresBall").Type), Mod.Find<ModItem>("MoltresBall").Type);}
			if(choice==3) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MewtwoBall").Type), Mod.Find<ModItem>("MewtwoBall").Type);}
			if(choice==4) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RaikouBall").Type), Mod.Find<ModItem>("RaikouBall").Type);}
			if(choice==5) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("EnteiBall").Type), Mod.Find<ModItem>("EnteiBall").Type);}
			if(choice==6) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SuicuneBall").Type), Mod.Find<ModItem>("SuicuneBall").Type);}
			if(choice==7) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("LugiaBall").Type), Mod.Find<ModItem>("LugiaBall").Type);}
			if(choice==8) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("HoohBall").Type), Mod.Find<ModItem>("HoohBall").Type);}
			if(choice==9) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RegirockBall").Type), Mod.Find<ModItem>("RegirockBall").Type);}
			if(choice==10) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RegiceBall").Type), Mod.Find<ModItem>("RegiceBall").Type);}
			if(choice==11) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RegisteelBall").Type), Mod.Find<ModItem>("RegisteelBall").Type);}
			if(choice==12) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("LatiasBall").Type), Mod.Find<ModItem>("LatiasBall").Type);}
			if(choice==13) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("KyogreBall").Type), Mod.Find<ModItem>("KyogreBall").Type);}
			if(choice==14) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GroudonBall").Type), Mod.Find<ModItem>("GroudonBall").Type);}
			if(choice==15) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RayquazaBall").Type), Mod.Find<ModItem>("RayquazaBall").Type);}
			if(choice==16) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("UxieBall").Type), Mod.Find<ModItem>("UxieBall").Type);}
			if(choice==17) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MespritBall").Type), Mod.Find<ModItem>("MespritBall").Type);}
			if(choice==18) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("AzelfBall").Type), Mod.Find<ModItem>("AzelfBall").Type);}
			if(choice==19) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DialgaBall").Type), Mod.Find<ModItem>("DialgaBall").Type);}
			if(choice==20) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PalkiaBall").Type), Mod.Find<ModItem>("PalkiaBall").Type);}
			if(choice==21) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("HeatranBall").Type), Mod.Find<ModItem>("HeatranBall").Type);}
			if(choice==22) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RegigigasBall").Type), Mod.Find<ModItem>("RegigigasBall").Type);}
			if(choice==23) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GiratinaBall").Type), Mod.Find<ModItem>("GiratinaBall").Type);}
			if(choice==24) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CresseliaBall").Type), Mod.Find<ModItem>("CresseliaBall").Type);}
			if(choice==25) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CobalionBall").Type), Mod.Find<ModItem>("CobalionBall").Type);}
			if(choice==26) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TerrakionBall").Type), Mod.Find<ModItem>("TerrakionBall").Type);}
			if(choice==27) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("VirizionBall").Type), Mod.Find<ModItem>("VirizionBall").Type);}
			if(choice==28) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TornadusBall").Type), Mod.Find<ModItem>("TornadusBall").Type);}
			if(choice==29) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ThundurusBall").Type), Mod.Find<ModItem>("ThundurusBall").Type);}
			if(choice==30) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ReshiramBall").Type), Mod.Find<ModItem>("ReshiramBall").Type);}
			if(choice==31) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ZekromBall").Type), Mod.Find<ModItem>("ZekromBall").Type);}
			if(choice==32) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("LandorusBall").Type), Mod.Find<ModItem>("LandorusBall").Type);}
			if(choice==33) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("KyuremBall").Type), Mod.Find<ModItem>("KyuremBall").Type);}
			if(choice==34) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("XerneasBall").Type), Mod.Find<ModItem>("XerneasBall").Type);}
			if(choice==35) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("YveltalBall").Type), Mod.Find<ModItem>("YveltalBall").Type);}
			if(choice==36) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CosmogBall").Type), Mod.Find<ModItem>("CosmogBall").Type);}
			if(choice==37) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("NecrozmaBall").Type), Mod.Find<ModItem>("NecrozmaBall").Type);}
			if(choice==38) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ZacianBall").Type), Mod.Find<ModItem>("ZacianBall").Type);}
			if(choice==39) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ZamazentaBall").Type), Mod.Find<ModItem>("ZamazentaBall").Type);}
			if(choice==40) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("EternatusBall").Type), Mod.Find<ModItem>("EternatusBall").Type);}

        }
	}
}
