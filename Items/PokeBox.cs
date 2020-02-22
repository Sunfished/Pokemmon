using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Pokemmon.Items
{
	public class PokeBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PokeBox");
			Tooltip.SetDefault("Contains a Stage 1 Pokemon");
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
            int choice = Main.rand.Next(309);
			if(choice==0) {player.QuickSpawnItem(mod.ItemType("CaterpieBall"));}
			if(choice==1) {player.QuickSpawnItem(mod.ItemType("WeedleBall"));}
			if(choice==2) {player.QuickSpawnItem(mod.ItemType("PidgeyBall"));}
			if(choice==3) {player.QuickSpawnItem(mod.ItemType("RattataBall"));}
			if(choice==4) {player.QuickSpawnItem(mod.ItemType("RattataAlolaBall"));}
			if(choice==5) {player.QuickSpawnItem(mod.ItemType("SpearowBall"));}
			if(choice==6) {player.QuickSpawnItem(mod.ItemType("EkansBall"));}
			if(choice==7) {player.QuickSpawnItem(mod.ItemType("SandshrewBall"));}
			if(choice==8) {player.QuickSpawnItem(mod.ItemType("SandshrewAlolaBall"));}
			if(choice==9) {player.QuickSpawnItem(mod.ItemType("NidoranFBall"));}
			if(choice==10) {player.QuickSpawnItem(mod.ItemType("NidoranMBall"));}
			if(choice==11) {player.QuickSpawnItem(mod.ItemType("VulpixBall"));}
			if(choice==12) {player.QuickSpawnItem(mod.ItemType("VulpixAlolaBall"));}
			if(choice==13) {player.QuickSpawnItem(mod.ItemType("JigglypuffBall"));}
			if(choice==14) {player.QuickSpawnItem(mod.ItemType("ZubatBall"));}
			if(choice==15) {player.QuickSpawnItem(mod.ItemType("OddishBall"));}
			if(choice==16) {player.QuickSpawnItem(mod.ItemType("ParasBall"));}
			if(choice==17) {player.QuickSpawnItem(mod.ItemType("VenonatBall"));}
			if(choice==18) {player.QuickSpawnItem(mod.ItemType("DiglettBall"));}
			if(choice==19) {player.QuickSpawnItem(mod.ItemType("DiglettAlolaBall"));}
			if(choice==20) {player.QuickSpawnItem(mod.ItemType("MeowthBall"));}
			if(choice==21) {player.QuickSpawnItem(mod.ItemType("MeowthAlolaBall"));}
			if(choice==22) {player.QuickSpawnItem(mod.ItemType("MeowthGalarBall"));}
			if(choice==23) {player.QuickSpawnItem(mod.ItemType("PsyduckBall"));}
			if(choice==24) {player.QuickSpawnItem(mod.ItemType("MankeyBall"));}
			if(choice==25) {player.QuickSpawnItem(mod.ItemType("GrowlitheBall"));}
			if(choice==26) {player.QuickSpawnItem(mod.ItemType("PoliwagBall"));}
			if(choice==27) {player.QuickSpawnItem(mod.ItemType("AbraBall"));}
			if(choice==28) {player.QuickSpawnItem(mod.ItemType("MachopBall"));}
			if(choice==29) {player.QuickSpawnItem(mod.ItemType("BellsproutBall"));}
			if(choice==30) {player.QuickSpawnItem(mod.ItemType("TentacoolBall"));}
			if(choice==31) {player.QuickSpawnItem(mod.ItemType("GeodudeBall"));}
			if(choice==32) {player.QuickSpawnItem(mod.ItemType("GeodudeAlolaBall"));}
			if(choice==33) {player.QuickSpawnItem(mod.ItemType("PonytaBall"));}
			if(choice==34) {player.QuickSpawnItem(mod.ItemType("PonytaGalarBall"));}
			if(choice==35) {player.QuickSpawnItem(mod.ItemType("SlowpokeBall"));}
			if(choice==36) {player.QuickSpawnItem(mod.ItemType("MagnemiteBall"));}
			if(choice==37) {player.QuickSpawnItem(mod.ItemType("FarfetchdGalarBall"));}
			if(choice==38) {player.QuickSpawnItem(mod.ItemType("DoduoBall"));}
			if(choice==39) {player.QuickSpawnItem(mod.ItemType("SeelBall"));}
			if(choice==40) {player.QuickSpawnItem(mod.ItemType("GrimerBall"));}
			if(choice==41) {player.QuickSpawnItem(mod.ItemType("GrimerAlolaBall"));}
			if(choice==42) {player.QuickSpawnItem(mod.ItemType("ShellderBall"));}
			if(choice==43) {player.QuickSpawnItem(mod.ItemType("GastlyBall"));}
			if(choice==44) {player.QuickSpawnItem(mod.ItemType("OnixBall"));}
			if(choice==45) {player.QuickSpawnItem(mod.ItemType("DrowzeeBall"));}
			if(choice==46) {player.QuickSpawnItem(mod.ItemType("KrabbyBall"));}
			if(choice==47) {player.QuickSpawnItem(mod.ItemType("VoltorbBall"));}
			if(choice==48) {player.QuickSpawnItem(mod.ItemType("ExeggcuteBall"));}
			if(choice==49) {player.QuickSpawnItem(mod.ItemType("CuboneBall"));}
			if(choice==50) {player.QuickSpawnItem(mod.ItemType("LickitungBall"));}
			if(choice==51) {player.QuickSpawnItem(mod.ItemType("KoffingBall"));}
			if(choice==52) {player.QuickSpawnItem(mod.ItemType("RhyhornBall"));}
			if(choice==53) {player.QuickSpawnItem(mod.ItemType("TangelaBall"));}
			if(choice==54) {player.QuickSpawnItem(mod.ItemType("HorseaBall"));}
			if(choice==55) {player.QuickSpawnItem(mod.ItemType("GoldeenBall"));}
			if(choice==56) {player.QuickSpawnItem(mod.ItemType("StaryuBall"));}
			if(choice==57) {player.QuickSpawnItem(mod.ItemType("MrMimeGalarBall"));}
			if(choice==58) {player.QuickSpawnItem(mod.ItemType("ScytherBall"));}
			if(choice==59) {player.QuickSpawnItem(mod.ItemType("MagikarpBall"));}
			if(choice==60) {player.QuickSpawnItem(mod.ItemType("EeveeBall"));}
			if(choice==61) {player.QuickSpawnItem(mod.ItemType("PorygonBall"));}
			if(choice==62) {player.QuickSpawnItem(mod.ItemType("OmanyteBall"));}
			if(choice==63) {player.QuickSpawnItem(mod.ItemType("KabutoBall"));}
			if(choice==64) {player.QuickSpawnItem(mod.ItemType("DratiniBall"));}
			if(choice==65) {player.QuickSpawnItem(mod.ItemType("SentretBall"));}
			if(choice==66) {player.QuickSpawnItem(mod.ItemType("HoothootBall"));}
			if(choice==67) {player.QuickSpawnItem(mod.ItemType("LedybaBall"));}
			if(choice==68) {player.QuickSpawnItem(mod.ItemType("SpinarakBall"));}
			if(choice==69) {player.QuickSpawnItem(mod.ItemType("ChinchouBall"));}
			if(choice==70) {player.QuickSpawnItem(mod.ItemType("NatuBall"));}
			if(choice==71) {player.QuickSpawnItem(mod.ItemType("MareepBall"));}
			if(choice==72) {player.QuickSpawnItem(mod.ItemType("HoppipBall"));}
			if(choice==73) {player.QuickSpawnItem(mod.ItemType("AipomBall"));}
			if(choice==74) {player.QuickSpawnItem(mod.ItemType("SunkernBall"));}
			if(choice==75) {player.QuickSpawnItem(mod.ItemType("YanmaBall"));}
			if(choice==76) {player.QuickSpawnItem(mod.ItemType("WooperBall"));}
			if(choice==77) {player.QuickSpawnItem(mod.ItemType("MurkrowBall"));}
			if(choice==78) {player.QuickSpawnItem(mod.ItemType("MisdreavusBall"));}
			if(choice==79) {player.QuickSpawnItem(mod.ItemType("PinecoBall"));}
			if(choice==80) {player.QuickSpawnItem(mod.ItemType("GligarBall"));}
			if(choice==81) {player.QuickSpawnItem(mod.ItemType("SnubbullBall"));}
			if(choice==82) {player.QuickSpawnItem(mod.ItemType("SneaselBall"));}
			if(choice==83) {player.QuickSpawnItem(mod.ItemType("TeddiursaBall"));}
			if(choice==84) {player.QuickSpawnItem(mod.ItemType("SlugmaBall"));}
			if(choice==85) {player.QuickSpawnItem(mod.ItemType("SwinubBall"));}
			if(choice==86) {player.QuickSpawnItem(mod.ItemType("CorsolaGalarBall"));}
			if(choice==87) {player.QuickSpawnItem(mod.ItemType("RemoraidBall"));}
			if(choice==88) {player.QuickSpawnItem(mod.ItemType("HoundourBall"));}
			if(choice==89) {player.QuickSpawnItem(mod.ItemType("PhanpyBall"));}
			if(choice==90) {player.QuickSpawnItem(mod.ItemType("LarvitarBall"));}
			if(choice==91) {player.QuickSpawnItem(mod.ItemType("PoochyenaBall"));}
			if(choice==92) {player.QuickSpawnItem(mod.ItemType("ZigzagoonBall"));}
			if(choice==93) {player.QuickSpawnItem(mod.ItemType("ZigzagoonGalarBall"));}
			if(choice==94) {player.QuickSpawnItem(mod.ItemType("WurmpleBall"));}
			if(choice==95) {player.QuickSpawnItem(mod.ItemType("LotadBall"));}
			if(choice==96) {player.QuickSpawnItem(mod.ItemType("SeedotBall"));}
			if(choice==97) {player.QuickSpawnItem(mod.ItemType("TaillowBall"));}
			if(choice==98) {player.QuickSpawnItem(mod.ItemType("WingullBall"));}
			if(choice==99) {player.QuickSpawnItem(mod.ItemType("RaltsBall"));}
			if(choice==100) {player.QuickSpawnItem(mod.ItemType("SurskitBall"));}
			if(choice==101) {player.QuickSpawnItem(mod.ItemType("ShroomishBall"));}
			if(choice==102) {player.QuickSpawnItem(mod.ItemType("SlakothBall"));}
			if(choice==103) {player.QuickSpawnItem(mod.ItemType("NincadaBall"));}
			if(choice==104) {player.QuickSpawnItem(mod.ItemType("WhismurBall"));}
			if(choice==105) {player.QuickSpawnItem(mod.ItemType("MakuhitaBall"));}
			if(choice==106) {player.QuickSpawnItem(mod.ItemType("NosepassBall"));}
			if(choice==107) {player.QuickSpawnItem(mod.ItemType("SkittyBall"));}
			if(choice==108) {player.QuickSpawnItem(mod.ItemType("AronBall"));}
			if(choice==109) {player.QuickSpawnItem(mod.ItemType("MedititeBall"));}
			if(choice==110) {player.QuickSpawnItem(mod.ItemType("ElectrikeBall"));}
			if(choice==111) {player.QuickSpawnItem(mod.ItemType("GulpinBall"));}
			if(choice==112) {player.QuickSpawnItem(mod.ItemType("CarvanhaBall"));}
			if(choice==113) {player.QuickSpawnItem(mod.ItemType("WailmerBall"));}
			if(choice==114) {player.QuickSpawnItem(mod.ItemType("NumelBall"));}
			if(choice==115) {player.QuickSpawnItem(mod.ItemType("SpoinkBall"));}
			if(choice==116) {player.QuickSpawnItem(mod.ItemType("TrapinchBall"));}
			if(choice==117) {player.QuickSpawnItem(mod.ItemType("CacneaBall"));}
			if(choice==118) {player.QuickSpawnItem(mod.ItemType("SwabluBall"));}
			if(choice==119) {player.QuickSpawnItem(mod.ItemType("BarboachBall"));}
			if(choice==120) {player.QuickSpawnItem(mod.ItemType("CorphishBall"));}
			if(choice==121) {player.QuickSpawnItem(mod.ItemType("BaltoyBall"));}
			if(choice==122) {player.QuickSpawnItem(mod.ItemType("LileepBall"));}
			if(choice==123) {player.QuickSpawnItem(mod.ItemType("AnorithBall"));}
			if(choice==124) {player.QuickSpawnItem(mod.ItemType("FeebasBall"));}
			if(choice==125) {player.QuickSpawnItem(mod.ItemType("ShuppetBall"));}
			if(choice==126) {player.QuickSpawnItem(mod.ItemType("DuskullBall"));}
			if(choice==127) {player.QuickSpawnItem(mod.ItemType("SnoruntBall"));}
			if(choice==128) {player.QuickSpawnItem(mod.ItemType("SphealBall"));}
			if(choice==129) {player.QuickSpawnItem(mod.ItemType("ClamperlBall"));}
			if(choice==130) {player.QuickSpawnItem(mod.ItemType("BagonBall"));}
			if(choice==131) {player.QuickSpawnItem(mod.ItemType("BeldumBall"));}
			if(choice==132) {player.QuickSpawnItem(mod.ItemType("StarlyBall"));}
			if(choice==133) {player.QuickSpawnItem(mod.ItemType("BidoofBall"));}
			if(choice==134) {player.QuickSpawnItem(mod.ItemType("KricketotBall"));}
			if(choice==135) {player.QuickSpawnItem(mod.ItemType("ShinxBall"));}
			if(choice==136) {player.QuickSpawnItem(mod.ItemType("CranidosBall"));}
			if(choice==137) {player.QuickSpawnItem(mod.ItemType("ShieldonBall"));}
			if(choice==138) {player.QuickSpawnItem(mod.ItemType("BurmyPlantCloakBall"));}
			if(choice==139) {player.QuickSpawnItem(mod.ItemType("BurmySandyCloakBall"));}
			if(choice==140) {player.QuickSpawnItem(mod.ItemType("BurmyTrashCloakBall"));}
			if(choice==141) {player.QuickSpawnItem(mod.ItemType("CombeeBall"));}
			if(choice==142) {player.QuickSpawnItem(mod.ItemType("BuizelBall"));}
			if(choice==143) {player.QuickSpawnItem(mod.ItemType("CherubiBall"));}
			if(choice==144) {player.QuickSpawnItem(mod.ItemType("ShellosWestSeaBall"));}
			if(choice==145) {player.QuickSpawnItem(mod.ItemType("ShellosEastSeaBall"));}
			if(choice==146) {player.QuickSpawnItem(mod.ItemType("DrifloonBall"));}
			if(choice==147) {player.QuickSpawnItem(mod.ItemType("BunearyBall"));}
			if(choice==148) {player.QuickSpawnItem(mod.ItemType("GlameowBall"));}
			if(choice==149) {player.QuickSpawnItem(mod.ItemType("StunkyBall"));}
			if(choice==150) {player.QuickSpawnItem(mod.ItemType("BronzorBall"));}
			if(choice==151) {player.QuickSpawnItem(mod.ItemType("GibleBall"));}
			if(choice==152) {player.QuickSpawnItem(mod.ItemType("MunchlaxBall"));}
			if(choice==153) {player.QuickSpawnItem(mod.ItemType("HippopotasBall"));}
			if(choice==154) {player.QuickSpawnItem(mod.ItemType("SkorupiBall"));}
			if(choice==155) {player.QuickSpawnItem(mod.ItemType("CroagunkBall"));}
			if(choice==156) {player.QuickSpawnItem(mod.ItemType("FinneonBall"));}
			if(choice==157) {player.QuickSpawnItem(mod.ItemType("SnoverBall"));}
			if(choice==158) {player.QuickSpawnItem(mod.ItemType("PatratBall"));}
			if(choice==159) {player.QuickSpawnItem(mod.ItemType("LillipupBall"));}
			if(choice==160) {player.QuickSpawnItem(mod.ItemType("PurrloinBall"));}
			if(choice==161) {player.QuickSpawnItem(mod.ItemType("PansageBall"));}
			if(choice==162) {player.QuickSpawnItem(mod.ItemType("PansearBall"));}
			if(choice==163) {player.QuickSpawnItem(mod.ItemType("PanpourBall"));}
			if(choice==164) {player.QuickSpawnItem(mod.ItemType("MunnaBall"));}
			if(choice==165) {player.QuickSpawnItem(mod.ItemType("PidoveBall"));}
			if(choice==166) {player.QuickSpawnItem(mod.ItemType("BlitzleBall"));}
			if(choice==167) {player.QuickSpawnItem(mod.ItemType("RoggenrolaBall"));}
			if(choice==168) {player.QuickSpawnItem(mod.ItemType("WoobatBall"));}
			if(choice==169) {player.QuickSpawnItem(mod.ItemType("DrilburBall"));}
			if(choice==170) {player.QuickSpawnItem(mod.ItemType("TimburrBall"));}
			if(choice==171) {player.QuickSpawnItem(mod.ItemType("TympoleBall"));}
			if(choice==172) {player.QuickSpawnItem(mod.ItemType("SewaddleBall"));}
			if(choice==173) {player.QuickSpawnItem(mod.ItemType("VenipedeBall"));}
			if(choice==174) {player.QuickSpawnItem(mod.ItemType("CottoneeBall"));}
			if(choice==175) {player.QuickSpawnItem(mod.ItemType("PetililBall"));}
			if(choice==176) {player.QuickSpawnItem(mod.ItemType("SandileBall"));}
			if(choice==177) {player.QuickSpawnItem(mod.ItemType("DarumakaBall"));}
			if(choice==178) {player.QuickSpawnItem(mod.ItemType("DarumakaGalarBall"));}
			if(choice==179) {player.QuickSpawnItem(mod.ItemType("DwebbleBall"));}
			if(choice==180) {player.QuickSpawnItem(mod.ItemType("ScraggyBall"));}
			if(choice==181) {player.QuickSpawnItem(mod.ItemType("YamaskBall"));}
			if(choice==182) {player.QuickSpawnItem(mod.ItemType("YamaskGalarBall"));}
			if(choice==183) {player.QuickSpawnItem(mod.ItemType("TirtougaBall"));}
			if(choice==184) {player.QuickSpawnItem(mod.ItemType("ArchenBall"));}
			if(choice==185) {player.QuickSpawnItem(mod.ItemType("TrubbishBall"));}
			if(choice==186) {player.QuickSpawnItem(mod.ItemType("ZoruaBall"));}
			if(choice==187) {player.QuickSpawnItem(mod.ItemType("MinccinoBall"));}
			if(choice==188) {player.QuickSpawnItem(mod.ItemType("GothitaBall"));}
			if(choice==189) {player.QuickSpawnItem(mod.ItemType("SolosisBall"));}
			if(choice==190) {player.QuickSpawnItem(mod.ItemType("DucklettBall"));}
			if(choice==191) {player.QuickSpawnItem(mod.ItemType("VanilliteBall"));}
			if(choice==192) {player.QuickSpawnItem(mod.ItemType("DeerlingSpringBall"));}
			if(choice==193) {player.QuickSpawnItem(mod.ItemType("DeerlingSummerBall"));}
			if(choice==194) {player.QuickSpawnItem(mod.ItemType("DeerlingAutumnBall"));}
			if(choice==195) {player.QuickSpawnItem(mod.ItemType("DeerlingWinterBall"));}
			if(choice==196) {player.QuickSpawnItem(mod.ItemType("KarrablastBall"));}
			if(choice==197) {player.QuickSpawnItem(mod.ItemType("FoongusBall"));}
			if(choice==198) {player.QuickSpawnItem(mod.ItemType("FrillishMBall"));}
			if(choice==199) {player.QuickSpawnItem(mod.ItemType("FrillishFBall"));}
			if(choice==200) {player.QuickSpawnItem(mod.ItemType("JoltikBall"));}
			if(choice==201) {player.QuickSpawnItem(mod.ItemType("FerroseedBall"));}
			if(choice==202) {player.QuickSpawnItem(mod.ItemType("KlinkBall"));}
			if(choice==203) {player.QuickSpawnItem(mod.ItemType("TynamoBall"));}
			if(choice==204) {player.QuickSpawnItem(mod.ItemType("ElgyemBall"));}
			if(choice==205) {player.QuickSpawnItem(mod.ItemType("LitwickBall"));}
			if(choice==206) {player.QuickSpawnItem(mod.ItemType("AxewBall"));}
			if(choice==207) {player.QuickSpawnItem(mod.ItemType("CubchooBall"));}
			if(choice==208) {player.QuickSpawnItem(mod.ItemType("ShelmetBall"));}
			if(choice==209) {player.QuickSpawnItem(mod.ItemType("MienfooBall"));}
			if(choice==210) {player.QuickSpawnItem(mod.ItemType("GolettBall"));}
			if(choice==211) {player.QuickSpawnItem(mod.ItemType("PawniardBall"));}
			if(choice==212) {player.QuickSpawnItem(mod.ItemType("RuffletBall"));}
			if(choice==213) {player.QuickSpawnItem(mod.ItemType("VullabyBall"));}
			if(choice==214) {player.QuickSpawnItem(mod.ItemType("DeinoBall"));}
			if(choice==215) {player.QuickSpawnItem(mod.ItemType("LarvestaBall"));}
			if(choice==216) {player.QuickSpawnItem(mod.ItemType("BunnelbyBall"));}
			if(choice==217) {player.QuickSpawnItem(mod.ItemType("FletchlingBall"));}
			if(choice==218) {player.QuickSpawnItem(mod.ItemType("ScatterbugBall"));}
			if(choice==219) {player.QuickSpawnItem(mod.ItemType("LitleoBall"));}
			if(choice==220) {player.QuickSpawnItem(mod.ItemType("FlabebeRedFlowerBall"));}
			if(choice==221) {player.QuickSpawnItem(mod.ItemType("FlabebeYellowFlowerBall"));}
			if(choice==222) {player.QuickSpawnItem(mod.ItemType("FlabebeOrangeFlowerBall"));}
			if(choice==223) {player.QuickSpawnItem(mod.ItemType("FlabebeBlueFlowerBall"));}
			if(choice==224) {player.QuickSpawnItem(mod.ItemType("FlabebeWhiteFlowerBall"));}
			if(choice==225) {player.QuickSpawnItem(mod.ItemType("SkiddoBall"));}
			if(choice==226) {player.QuickSpawnItem(mod.ItemType("PanchamBall"));}
			if(choice==227) {player.QuickSpawnItem(mod.ItemType("EspurrBall"));}
			if(choice==228) {player.QuickSpawnItem(mod.ItemType("HonedgeBall"));}
			if(choice==229) {player.QuickSpawnItem(mod.ItemType("SpritzeeBall"));}
			if(choice==230) {player.QuickSpawnItem(mod.ItemType("SwirlixBall"));}
			if(choice==231) {player.QuickSpawnItem(mod.ItemType("InkayBall"));}
			if(choice==232) {player.QuickSpawnItem(mod.ItemType("BinacleBall"));}
			if(choice==233) {player.QuickSpawnItem(mod.ItemType("SkrelpBall"));}
			if(choice==234) {player.QuickSpawnItem(mod.ItemType("ClauncherBall"));}
			if(choice==235) {player.QuickSpawnItem(mod.ItemType("HelioptileBall"));}
			if(choice==236) {player.QuickSpawnItem(mod.ItemType("TyruntBall"));}
			if(choice==237) {player.QuickSpawnItem(mod.ItemType("AmauraBall"));}
			if(choice==238) {player.QuickSpawnItem(mod.ItemType("GoomyBall"));}
			if(choice==239) {player.QuickSpawnItem(mod.ItemType("PhantumpBall"));}
			if(choice==240) {player.QuickSpawnItem(mod.ItemType("PumpkabooSmallSizeBall"));}
			if(choice==241) {player.QuickSpawnItem(mod.ItemType("PumpkabooAverageSizeBall"));}
			if(choice==242) {player.QuickSpawnItem(mod.ItemType("PumpkabooLargeSizeBall"));}
			if(choice==243) {player.QuickSpawnItem(mod.ItemType("PumpkabooSuperSizeBall"));}
			if(choice==244) {player.QuickSpawnItem(mod.ItemType("BergmiteBall"));}
			if(choice==245) {player.QuickSpawnItem(mod.ItemType("NoibatBall"));}
			if(choice==246) {player.QuickSpawnItem(mod.ItemType("PikipekBall"));}
			if(choice==247) {player.QuickSpawnItem(mod.ItemType("YungoosBall"));}
			if(choice==248) {player.QuickSpawnItem(mod.ItemType("GrubbinBall"));}
			if(choice==249) {player.QuickSpawnItem(mod.ItemType("CrabrawlerBall"));}
			if(choice==250) {player.QuickSpawnItem(mod.ItemType("CutieflyBall"));}
			if(choice==251) {player.QuickSpawnItem(mod.ItemType("RockruffBall"));}
			if(choice==252) {player.QuickSpawnItem(mod.ItemType("MareanieBall"));}
			if(choice==253) {player.QuickSpawnItem(mod.ItemType("MudbrayBall"));}
			if(choice==254) {player.QuickSpawnItem(mod.ItemType("DewpiderBall"));}
			if(choice==255) {player.QuickSpawnItem(mod.ItemType("FomantisBall"));}
			if(choice==256) {player.QuickSpawnItem(mod.ItemType("MorelullBall"));}
			if(choice==257) {player.QuickSpawnItem(mod.ItemType("SalanditBall"));}
			if(choice==258) {player.QuickSpawnItem(mod.ItemType("StuffulBall"));}
			if(choice==259) {player.QuickSpawnItem(mod.ItemType("BounsweetBall"));}
			if(choice==260) {player.QuickSpawnItem(mod.ItemType("WimpodBall"));}
			if(choice==261) {player.QuickSpawnItem(mod.ItemType("SandygastBall"));}
			if(choice==262) {player.QuickSpawnItem(mod.ItemType("JangmooBall"));}
			if(choice==263) {player.QuickSpawnItem(mod.ItemType("CosmogBall"));}
			if(choice==264) {player.QuickSpawnItem(mod.ItemType("SkowvetBall"));}
			if(choice==265) {player.QuickSpawnItem(mod.ItemType("RookideeBall"));}
			if(choice==266) {player.QuickSpawnItem(mod.ItemType("BlipbugBall"));}
			if(choice==267) {player.QuickSpawnItem(mod.ItemType("NickitBall"));}
			if(choice==268) {player.QuickSpawnItem(mod.ItemType("GossifleurBall"));}
			if(choice==269) {player.QuickSpawnItem(mod.ItemType("WoolooBall"));}
			if(choice==270) {player.QuickSpawnItem(mod.ItemType("ChewtleBall"));}
			if(choice==271) {player.QuickSpawnItem(mod.ItemType("YamperBall"));}
			if(choice==272) {player.QuickSpawnItem(mod.ItemType("RolycolyBall"));}
			if(choice==273) {player.QuickSpawnItem(mod.ItemType("ApplinBall"));}
			if(choice==274) {player.QuickSpawnItem(mod.ItemType("SilicobraBall"));}
			if(choice==275) {player.QuickSpawnItem(mod.ItemType("ArrokudaBall"));}
			if(choice==276) {player.QuickSpawnItem(mod.ItemType("SizzlipedeBall"));}
			if(choice==277) {player.QuickSpawnItem(mod.ItemType("ClobbopusBall"));}
			if(choice==278) {player.QuickSpawnItem(mod.ItemType("SinisteaPhonyBall"));}
			if(choice==279) {player.QuickSpawnItem(mod.ItemType("HatennaBall"));}
			if(choice==280) {player.QuickSpawnItem(mod.ItemType("ImpidimpBall"));}
			if(choice==281) {player.QuickSpawnItem(mod.ItemType("MilceryBall"));}
			if(choice==282) {player.QuickSpawnItem(mod.ItemType("SnomBall"));}
			if(choice==283) {player.QuickSpawnItem(mod.ItemType("CufantBall"));}
			if(choice==284) {player.QuickSpawnItem(mod.ItemType("DreepyBall"));}
			if(choice==285) {player.QuickSpawnItem(mod.ItemType("SyclarBall"));}
			if(choice==286) {player.QuickSpawnItem(mod.ItemType("EmbirchBall"));}
			if(choice==287) {player.QuickSpawnItem(mod.ItemType("BreeziBall"));}
			if(choice==288) {player.QuickSpawnItem(mod.ItemType("RebbleBall"));}
			if(choice==289) {player.QuickSpawnItem(mod.ItemType("PrivatykeBall"));}
			if(choice==290) {player.QuickSpawnItem(mod.ItemType("NohfaceBall"));}
			if(choice==291) {player.QuickSpawnItem(mod.ItemType("MonohmBall"));}
			if(choice==292) {player.QuickSpawnItem(mod.ItemType("C1Ball"));}
			if(choice==293) {player.QuickSpawnItem(mod.ItemType("ProtowattBall"));}
			if(choice==294) {player.QuickSpawnItem(mod.ItemType("VoodollBall"));}
			if(choice==295) {player.QuickSpawnItem(mod.ItemType("ScratchetBall"));}
			if(choice==296) {player.QuickSpawnItem(mod.ItemType("NecturineBall"));}
			if(choice==297) {player.QuickSpawnItem(mod.ItemType("CupraBall"));}
			if(choice==298) {player.QuickSpawnItem(mod.ItemType("BrattlerBall"));}
			if(choice==299) {player.QuickSpawnItem(mod.ItemType("CawdetBall"));}
			if(choice==300) {player.QuickSpawnItem(mod.ItemType("VolkritterBall"));}
			if(choice==301) {player.QuickSpawnItem(mod.ItemType("SnugglowBall"));}
			if(choice==302) {player.QuickSpawnItem(mod.ItemType("FloatoyBall"));}
			if(choice==303) {player.QuickSpawnItem(mod.ItemType("PluffleBall"));}
			if(choice==304) {player.QuickSpawnItem(mod.ItemType("MumbaoBall"));}
			if(choice==305) {player.QuickSpawnItem(mod.ItemType("FawniferBall"));}
			if(choice==306) {player.QuickSpawnItem(mod.ItemType("SmogeckoBall"));}
			if(choice==307) {player.QuickSpawnItem(mod.ItemType("SwirlpoolBall"));}
			if(choice==308) {player.QuickSpawnItem(mod.ItemType("JustykeBall"));}

        }
	}
}
