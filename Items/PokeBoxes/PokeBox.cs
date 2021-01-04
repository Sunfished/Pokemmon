using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Pokemmon.Items.PokeBoxes
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
			item.value = 350000;
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
            int choice = Main.rand.Next(52308);
			if(choice<255) {player.QuickSpawnItem(mod.ItemType("CaterpieBall"));}
			if(choice<510) {player.QuickSpawnItem(mod.ItemType("WeedleBall"));}
			if(choice<765) {player.QuickSpawnItem(mod.ItemType("PidgeyBall"));}
			if(choice<1020) {player.QuickSpawnItem(mod.ItemType("RattataBall"));}
			if(choice<1275) {player.QuickSpawnItem(mod.ItemType("RattataAlolaBall"));}
			if(choice<1530) {player.QuickSpawnItem(mod.ItemType("SpearowBall"));}
			if(choice<1785) {player.QuickSpawnItem(mod.ItemType("EkansBall"));}
			if(choice<2040) {player.QuickSpawnItem(mod.ItemType("SandshrewBall"));}
			if(choice<2295) {player.QuickSpawnItem(mod.ItemType("SandshrewAlolaBall"));}
			if(choice<2530) {player.QuickSpawnItem(mod.ItemType("NidoranFBall"));}
			if(choice<2765) {player.QuickSpawnItem(mod.ItemType("NidoranMBall"));}
			if(choice<2955) {player.QuickSpawnItem(mod.ItemType("VulpixBall"));}
			if(choice<3145) {player.QuickSpawnItem(mod.ItemType("VulpixAlolaBall"));}
			if(choice<3315) {player.QuickSpawnItem(mod.ItemType("JigglypuffBall"));}
			if(choice<3570) {player.QuickSpawnItem(mod.ItemType("ZubatBall"));}
			if(choice<3825) {player.QuickSpawnItem(mod.ItemType("OddishBall"));}
			if(choice<4015) {player.QuickSpawnItem(mod.ItemType("ParasBall"));}
			if(choice<4205) {player.QuickSpawnItem(mod.ItemType("VenonatBall"));}
			if(choice<4460) {player.QuickSpawnItem(mod.ItemType("DiglettBall"));}
			if(choice<4715) {player.QuickSpawnItem(mod.ItemType("DiglettAlolaBall"));}
			if(choice<4970) {player.QuickSpawnItem(mod.ItemType("MeowthBall"));}
			if(choice<5225) {player.QuickSpawnItem(mod.ItemType("MeowthAlolaBall"));}
			if(choice<5480) {player.QuickSpawnItem(mod.ItemType("MeowthGalarBall"));}
			if(choice<5670) {player.QuickSpawnItem(mod.ItemType("PsyduckBall"));}
			if(choice<5860) {player.QuickSpawnItem(mod.ItemType("MankeyBall"));}
			if(choice<6050) {player.QuickSpawnItem(mod.ItemType("GrowlitheBall"));}
			if(choice<6305) {player.QuickSpawnItem(mod.ItemType("PoliwagBall"));}
			if(choice<6505) {player.QuickSpawnItem(mod.ItemType("AbraBall"));}
			if(choice<6685) {player.QuickSpawnItem(mod.ItemType("MachopBall"));}
			if(choice<6940) {player.QuickSpawnItem(mod.ItemType("BellsproutBall"));}
			if(choice<7130) {player.QuickSpawnItem(mod.ItemType("TentacoolBall"));}
			if(choice<7385) {player.QuickSpawnItem(mod.ItemType("GeodudeBall"));}
			if(choice<7640) {player.QuickSpawnItem(mod.ItemType("GeodudeAlolaBall"));}
			if(choice<7830) {player.QuickSpawnItem(mod.ItemType("PonytaBall"));}
			if(choice<8020) {player.QuickSpawnItem(mod.ItemType("PonytaGalarBall"));}
			if(choice<8210) {player.QuickSpawnItem(mod.ItemType("SlowpokeBall"));}
			if(choice<8400) {player.QuickSpawnItem(mod.ItemType("SlowpokeGalarBall"));}
			if(choice<8590) {player.QuickSpawnItem(mod.ItemType("MagnemiteBall"));}
			if(choice<8635) {player.QuickSpawnItem(mod.ItemType("FarfetchdGalarBall"));}
			if(choice<8825) {player.QuickSpawnItem(mod.ItemType("DoduoBall"));}
			if(choice<9015) {player.QuickSpawnItem(mod.ItemType("SeelBall"));}
			if(choice<9205) {player.QuickSpawnItem(mod.ItemType("GrimerBall"));}
			if(choice<9395) {player.QuickSpawnItem(mod.ItemType("GrimerAlolaBall"));}
			if(choice<9585) {player.QuickSpawnItem(mod.ItemType("ShellderBall"));}
			if(choice<9775) {player.QuickSpawnItem(mod.ItemType("GastlyBall"));}
			if(choice<9820) {player.QuickSpawnItem(mod.ItemType("OnixBall"));}
			if(choice<10010) {player.QuickSpawnItem(mod.ItemType("DrowzeeBall"));}
			if(choice<10235) {player.QuickSpawnItem(mod.ItemType("KrabbyBall"));}
			if(choice<10425) {player.QuickSpawnItem(mod.ItemType("VoltorbBall"));}
			if(choice<10515) {player.QuickSpawnItem(mod.ItemType("ExeggcuteBall"));}
			if(choice<10705) {player.QuickSpawnItem(mod.ItemType("CuboneBall"));}
			if(choice<10750) {player.QuickSpawnItem(mod.ItemType("LickitungBall"));}
			if(choice<10940) {player.QuickSpawnItem(mod.ItemType("KoffingBall"));}
			if(choice<11060) {player.QuickSpawnItem(mod.ItemType("RhyhornBall"));}
			if(choice<11105) {player.QuickSpawnItem(mod.ItemType("TangelaBall"));}
			if(choice<11330) {player.QuickSpawnItem(mod.ItemType("HorseaBall"));}
			if(choice<11555) {player.QuickSpawnItem(mod.ItemType("GoldeenBall"));}
			if(choice<11780) {player.QuickSpawnItem(mod.ItemType("StaryuBall"));}
			if(choice<11825) {player.QuickSpawnItem(mod.ItemType("ScytherBall"));}
			if(choice<12080) {player.QuickSpawnItem(mod.ItemType("MagikarpBall"));}
			if(choice<12125) {player.QuickSpawnItem(mod.ItemType("EeveeBall"));}
			if(choice<12170) {player.QuickSpawnItem(mod.ItemType("PorygonBall"));}
			if(choice<12215) {player.QuickSpawnItem(mod.ItemType("DratiniBall"));}
			if(choice<12470) {player.QuickSpawnItem(mod.ItemType("SentretBall"));}
			if(choice<12725) {player.QuickSpawnItem(mod.ItemType("HoothootBall"));}
			if(choice<12980) {player.QuickSpawnItem(mod.ItemType("LedybaBall"));}
			if(choice<13235) {player.QuickSpawnItem(mod.ItemType("SpinarakBall"));}
			if(choice<13425) {player.QuickSpawnItem(mod.ItemType("ChinchouBall"));}
			if(choice<13615) {player.QuickSpawnItem(mod.ItemType("NatuBall"));}
			if(choice<13850) {player.QuickSpawnItem(mod.ItemType("MareepBall"));}
			if(choice<14105) {player.QuickSpawnItem(mod.ItemType("HoppipBall"));}
			if(choice<14150) {player.QuickSpawnItem(mod.ItemType("AipomBall"));}
			if(choice<14385) {player.QuickSpawnItem(mod.ItemType("SunkernBall"));}
			if(choice<14460) {player.QuickSpawnItem(mod.ItemType("YanmaBall"));}
			if(choice<14715) {player.QuickSpawnItem(mod.ItemType("WooperBall"));}
			if(choice<14745) {player.QuickSpawnItem(mod.ItemType("MurkrowBall"));}
			if(choice<14790) {player.QuickSpawnItem(mod.ItemType("MisdreavusBall"));}
			if(choice<14980) {player.QuickSpawnItem(mod.ItemType("PinecoBall"));}
			if(choice<15040) {player.QuickSpawnItem(mod.ItemType("GligarBall"));}
			if(choice<15230) {player.QuickSpawnItem(mod.ItemType("SnubbullBall"));}
			if(choice<15290) {player.QuickSpawnItem(mod.ItemType("SneaselBall"));}
			if(choice<15410) {player.QuickSpawnItem(mod.ItemType("TeddiursaBall"));}
			if(choice<15600) {player.QuickSpawnItem(mod.ItemType("SlugmaBall"));}
			if(choice<15825) {player.QuickSpawnItem(mod.ItemType("SwinubBall"));}
			if(choice<15885) {player.QuickSpawnItem(mod.ItemType("CorsolaGalarBall"));}
			if(choice<16075) {player.QuickSpawnItem(mod.ItemType("RemoraidBall"));}
			if(choice<16195) {player.QuickSpawnItem(mod.ItemType("HoundourBall"));}
			if(choice<16315) {player.QuickSpawnItem(mod.ItemType("PhanpyBall"));}
			if(choice<16360) {player.QuickSpawnItem(mod.ItemType("LarvitarBall"));}
			if(choice<16615) {player.QuickSpawnItem(mod.ItemType("PoochyenaBall"));}
			if(choice<16870) {player.QuickSpawnItem(mod.ItemType("ZigzagoonBall"));}
			if(choice<17125) {player.QuickSpawnItem(mod.ItemType("ZigzagoonGalarBall"));}
			if(choice<17380) {player.QuickSpawnItem(mod.ItemType("WurmpleBall"));}
			if(choice<17635) {player.QuickSpawnItem(mod.ItemType("LotadBall"));}
			if(choice<17890) {player.QuickSpawnItem(mod.ItemType("SeedotBall"));}
			if(choice<18090) {player.QuickSpawnItem(mod.ItemType("TaillowBall"));}
			if(choice<18280) {player.QuickSpawnItem(mod.ItemType("WingullBall"));}
			if(choice<18515) {player.QuickSpawnItem(mod.ItemType("RaltsBall"));}
			if(choice<18715) {player.QuickSpawnItem(mod.ItemType("SurskitBall"));}
			if(choice<18970) {player.QuickSpawnItem(mod.ItemType("ShroomishBall"));}
			if(choice<19225) {player.QuickSpawnItem(mod.ItemType("SlakothBall"));}
			if(choice<19480) {player.QuickSpawnItem(mod.ItemType("NincadaBall"));}
			if(choice<19670) {player.QuickSpawnItem(mod.ItemType("WhismurBall"));}
			if(choice<19850) {player.QuickSpawnItem(mod.ItemType("MakuhitaBall"));}
			if(choice<20105) {player.QuickSpawnItem(mod.ItemType("NosepassBall"));}
			if(choice<20360) {player.QuickSpawnItem(mod.ItemType("SkittyBall"));}
			if(choice<20540) {player.QuickSpawnItem(mod.ItemType("AronBall"));}
			if(choice<20720) {player.QuickSpawnItem(mod.ItemType("MedititeBall"));}
			if(choice<20840) {player.QuickSpawnItem(mod.ItemType("ElectrikeBall"));}
			if(choice<21065) {player.QuickSpawnItem(mod.ItemType("GulpinBall"));}
			if(choice<21290) {player.QuickSpawnItem(mod.ItemType("CarvanhaBall"));}
			if(choice<21415) {player.QuickSpawnItem(mod.ItemType("WailmerBall"));}
			if(choice<21670) {player.QuickSpawnItem(mod.ItemType("NumelBall"));}
			if(choice<21925) {player.QuickSpawnItem(mod.ItemType("SpoinkBall"));}
			if(choice<22180) {player.QuickSpawnItem(mod.ItemType("TrapinchBall"));}
			if(choice<22370) {player.QuickSpawnItem(mod.ItemType("CacneaBall"));}
			if(choice<22625) {player.QuickSpawnItem(mod.ItemType("SwabluBall"));}
			if(choice<22815) {player.QuickSpawnItem(mod.ItemType("BarboachBall"));}
			if(choice<23020) {player.QuickSpawnItem(mod.ItemType("CorphishBall"));}
			if(choice<23275) {player.QuickSpawnItem(mod.ItemType("BaltoyBall"));}
			if(choice<23530) {player.QuickSpawnItem(mod.ItemType("FeebasBall"));}
			if(choice<23755) {player.QuickSpawnItem(mod.ItemType("ShuppetBall"));}
			if(choice<23945) {player.QuickSpawnItem(mod.ItemType("DuskullBall"));}
			if(choice<24135) {player.QuickSpawnItem(mod.ItemType("SnoruntBall"));}
			if(choice<24390) {player.QuickSpawnItem(mod.ItemType("SphealBall"));}
			if(choice<24645) {player.QuickSpawnItem(mod.ItemType("ClamperlBall"));}
			if(choice<24690) {player.QuickSpawnItem(mod.ItemType("BagonBall"));}
			if(choice<24693) {player.QuickSpawnItem(mod.ItemType("BeldumBall"));}
			if(choice<24948) {player.QuickSpawnItem(mod.ItemType("StarlyBall"));}
			if(choice<25203) {player.QuickSpawnItem(mod.ItemType("BidoofBall"));}
			if(choice<25458) {player.QuickSpawnItem(mod.ItemType("KricketotBall"));}
			if(choice<25693) {player.QuickSpawnItem(mod.ItemType("ShinxBall"));}
			if(choice<25813) {player.QuickSpawnItem(mod.ItemType("BurmyPlantCloakBall"));}
			if(choice<25933) {player.QuickSpawnItem(mod.ItemType("BurmySandyCloakBall"));}
			if(choice<26053) {player.QuickSpawnItem(mod.ItemType("BurmyTrashCloakBall"));}
			if(choice<26173) {player.QuickSpawnItem(mod.ItemType("CombeeBall"));}
			if(choice<26363) {player.QuickSpawnItem(mod.ItemType("BuizelBall"));}
			if(choice<26553) {player.QuickSpawnItem(mod.ItemType("CherubiBall"));}
			if(choice<26743) {player.QuickSpawnItem(mod.ItemType("ShellosWestSeaBall"));}
			if(choice<26933) {player.QuickSpawnItem(mod.ItemType("ShellosEastSeaBall"));}
			if(choice<27058) {player.QuickSpawnItem(mod.ItemType("DrifloonBall"));}
			if(choice<27248) {player.QuickSpawnItem(mod.ItemType("BunearyBall"));}
			if(choice<27438) {player.QuickSpawnItem(mod.ItemType("GlameowBall"));}
			if(choice<27663) {player.QuickSpawnItem(mod.ItemType("StunkyBall"));}
			if(choice<27918) {player.QuickSpawnItem(mod.ItemType("BronzorBall"));}
			if(choice<27963) {player.QuickSpawnItem(mod.ItemType("GibleBall"));}
			if(choice<28013) {player.QuickSpawnItem(mod.ItemType("MunchlaxBall"));}
			if(choice<28153) {player.QuickSpawnItem(mod.ItemType("HippopotasBall"));}
			if(choice<28273) {player.QuickSpawnItem(mod.ItemType("SkorupiBall"));}
			if(choice<28413) {player.QuickSpawnItem(mod.ItemType("CroagunkBall"));}
			if(choice<28603) {player.QuickSpawnItem(mod.ItemType("FinneonBall"));}
			if(choice<28723) {player.QuickSpawnItem(mod.ItemType("SnoverBall"));}
			if(choice<28978) {player.QuickSpawnItem(mod.ItemType("PatratBall"));}
			if(choice<29233) {player.QuickSpawnItem(mod.ItemType("LillipupBall"));}
			if(choice<29488) {player.QuickSpawnItem(mod.ItemType("PurrloinBall"));}
			if(choice<29678) {player.QuickSpawnItem(mod.ItemType("PansageBall"));}
			if(choice<29868) {player.QuickSpawnItem(mod.ItemType("PansearBall"));}
			if(choice<30058) {player.QuickSpawnItem(mod.ItemType("PanpourBall"));}
			if(choice<30248) {player.QuickSpawnItem(mod.ItemType("MunnaBall"));}
			if(choice<30503) {player.QuickSpawnItem(mod.ItemType("PidoveBall"));}
			if(choice<30693) {player.QuickSpawnItem(mod.ItemType("BlitzleBall"));}
			if(choice<30948) {player.QuickSpawnItem(mod.ItemType("RoggenrolaBall"));}
			if(choice<31138) {player.QuickSpawnItem(mod.ItemType("WoobatBall"));}
			if(choice<31258) {player.QuickSpawnItem(mod.ItemType("DrilburBall"));}
			if(choice<31438) {player.QuickSpawnItem(mod.ItemType("TimburrBall"));}
			if(choice<31693) {player.QuickSpawnItem(mod.ItemType("TympoleBall"));}
			if(choice<31948) {player.QuickSpawnItem(mod.ItemType("SewaddleBall"));}
			if(choice<32203) {player.QuickSpawnItem(mod.ItemType("VenipedeBall"));}
			if(choice<32393) {player.QuickSpawnItem(mod.ItemType("CottoneeBall"));}
			if(choice<32583) {player.QuickSpawnItem(mod.ItemType("PetililBall"));}
			if(choice<32763) {player.QuickSpawnItem(mod.ItemType("SandileBall"));}
			if(choice<32883) {player.QuickSpawnItem(mod.ItemType("DarumakaBall"));}
			if(choice<33003) {player.QuickSpawnItem(mod.ItemType("DarumakaGalarBall"));}
			if(choice<33193) {player.QuickSpawnItem(mod.ItemType("DwebbleBall"));}
			if(choice<33373) {player.QuickSpawnItem(mod.ItemType("ScraggyBall"));}
			if(choice<33563) {player.QuickSpawnItem(mod.ItemType("YamaskBall"));}
			if(choice<33753) {player.QuickSpawnItem(mod.ItemType("YamaskGalarBall"));}
			if(choice<33943) {player.QuickSpawnItem(mod.ItemType("TrubbishBall"));}
			if(choice<34018) {player.QuickSpawnItem(mod.ItemType("ZoruaBall"));}
			if(choice<34273) {player.QuickSpawnItem(mod.ItemType("MinccinoBall"));}
			if(choice<34473) {player.QuickSpawnItem(mod.ItemType("GothitaBall"));}
			if(choice<34673) {player.QuickSpawnItem(mod.ItemType("SolosisBall"));}
			if(choice<34863) {player.QuickSpawnItem(mod.ItemType("DucklettBall"));}
			if(choice<35118) {player.QuickSpawnItem(mod.ItemType("VanilliteBall"));}
			if(choice<35308) {player.QuickSpawnItem(mod.ItemType("DeerlingSpringBall"));}
			if(choice<35498) {player.QuickSpawnItem(mod.ItemType("DeerlingSummerBall"));}
			if(choice<35688) {player.QuickSpawnItem(mod.ItemType("DeerlingAutumnBall"));}
			if(choice<35878) {player.QuickSpawnItem(mod.ItemType("DeerlingWinterBall"));}
			if(choice<36078) {player.QuickSpawnItem(mod.ItemType("KarrablastBall"));}
			if(choice<36268) {player.QuickSpawnItem(mod.ItemType("FoongusBall"));}
			if(choice<36458) {player.QuickSpawnItem(mod.ItemType("FrillishMBall"));}
			if(choice<36648) {player.QuickSpawnItem(mod.ItemType("FrillishFBall"));}
			if(choice<36838) {player.QuickSpawnItem(mod.ItemType("JoltikBall"));}
			if(choice<37093) {player.QuickSpawnItem(mod.ItemType("FerroseedBall"));}
			if(choice<37223) {player.QuickSpawnItem(mod.ItemType("KlinkBall"));}
			if(choice<37413) {player.QuickSpawnItem(mod.ItemType("TynamoBall"));}
			if(choice<37668) {player.QuickSpawnItem(mod.ItemType("ElgyemBall"));}
			if(choice<37858) {player.QuickSpawnItem(mod.ItemType("LitwickBall"));}
			if(choice<37933) {player.QuickSpawnItem(mod.ItemType("AxewBall"));}
			if(choice<38053) {player.QuickSpawnItem(mod.ItemType("CubchooBall"));}
			if(choice<38253) {player.QuickSpawnItem(mod.ItemType("ShelmetBall"));}
			if(choice<38433) {player.QuickSpawnItem(mod.ItemType("MienfooBall"));}
			if(choice<38623) {player.QuickSpawnItem(mod.ItemType("GolettBall"));}
			if(choice<38743) {player.QuickSpawnItem(mod.ItemType("PawniardBall"));}
			if(choice<38933) {player.QuickSpawnItem(mod.ItemType("RuffletBall"));}
			if(choice<39123) {player.QuickSpawnItem(mod.ItemType("VullabyBall"));}
			if(choice<39168) {player.QuickSpawnItem(mod.ItemType("DeinoBall"));}
			if(choice<39213) {player.QuickSpawnItem(mod.ItemType("LarvestaBall"));}
			if(choice<39468) {player.QuickSpawnItem(mod.ItemType("BunnelbyBall"));}
			if(choice<39723) {player.QuickSpawnItem(mod.ItemType("FletchlingBall"));}
			if(choice<39978) {player.QuickSpawnItem(mod.ItemType("ScatterbugBall"));}
			if(choice<40198) {player.QuickSpawnItem(mod.ItemType("LitleoBall"));}
			if(choice<40423) {player.QuickSpawnItem(mod.ItemType("FlabebeRedFlowerBall"));}
			if(choice<40648) {player.QuickSpawnItem(mod.ItemType("FlabebeYellowFlowerBall"));}
			if(choice<40873) {player.QuickSpawnItem(mod.ItemType("FlabebeOrangeFlowerBall"));}
			if(choice<41098) {player.QuickSpawnItem(mod.ItemType("FlabebeBlueFlowerBall"));}
			if(choice<41323) {player.QuickSpawnItem(mod.ItemType("FlabebeWhiteFlowerBall"));}
			if(choice<41523) {player.QuickSpawnItem(mod.ItemType("SkiddoBall"));}
			if(choice<41743) {player.QuickSpawnItem(mod.ItemType("PanchamBall"));}
			if(choice<41933) {player.QuickSpawnItem(mod.ItemType("EspurrBall"));}
			if(choice<42113) {player.QuickSpawnItem(mod.ItemType("HonedgeBall"));}
			if(choice<42313) {player.QuickSpawnItem(mod.ItemType("SpritzeeBall"));}
			if(choice<42513) {player.QuickSpawnItem(mod.ItemType("SwirlixBall"));}
			if(choice<42703) {player.QuickSpawnItem(mod.ItemType("InkayBall"));}
			if(choice<42823) {player.QuickSpawnItem(mod.ItemType("BinacleBall"));}
			if(choice<43048) {player.QuickSpawnItem(mod.ItemType("SkrelpBall"));}
			if(choice<43273) {player.QuickSpawnItem(mod.ItemType("ClauncherBall"));}
			if(choice<43463) {player.QuickSpawnItem(mod.ItemType("HelioptileBall"));}
			if(choice<43508) {player.QuickSpawnItem(mod.ItemType("GoomyBall"));}
			if(choice<43628) {player.QuickSpawnItem(mod.ItemType("PhantumpBall"));}
			if(choice<43748) {player.QuickSpawnItem(mod.ItemType("PumpkabooSmallSizeBall"));}
			if(choice<43868) {player.QuickSpawnItem(mod.ItemType("PumpkabooAverageSizeBall"));}
			if(choice<43988) {player.QuickSpawnItem(mod.ItemType("PumpkabooLargeSizeBall"));}
			if(choice<44108) {player.QuickSpawnItem(mod.ItemType("PumpkabooSuperSizeBall"));}
			if(choice<44298) {player.QuickSpawnItem(mod.ItemType("BergmiteBall"));}
			if(choice<44488) {player.QuickSpawnItem(mod.ItemType("NoibatBall"));}
			if(choice<44743) {player.QuickSpawnItem(mod.ItemType("PikipekBall"));}
			if(choice<44998) {player.QuickSpawnItem(mod.ItemType("YungoosBall"));}
			if(choice<45253) {player.QuickSpawnItem(mod.ItemType("GrubbinBall"));}
			if(choice<45478) {player.QuickSpawnItem(mod.ItemType("CrabrawlerBall"));}
			if(choice<45668) {player.QuickSpawnItem(mod.ItemType("CutieflyBall"));}
			if(choice<45858) {player.QuickSpawnItem(mod.ItemType("RockruffBall"));}
			if(choice<46048) {player.QuickSpawnItem(mod.ItemType("MareanieBall"));}
			if(choice<46238) {player.QuickSpawnItem(mod.ItemType("MudbrayBall"));}
			if(choice<46438) {player.QuickSpawnItem(mod.ItemType("DewpiderBall"));}
			if(choice<46628) {player.QuickSpawnItem(mod.ItemType("FomantisBall"));}
			if(choice<46818) {player.QuickSpawnItem(mod.ItemType("MorelullBall"));}
			if(choice<46938) {player.QuickSpawnItem(mod.ItemType("SalanditBall"));}
			if(choice<47078) {player.QuickSpawnItem(mod.ItemType("StuffulBall"));}
			if(choice<47313) {player.QuickSpawnItem(mod.ItemType("BounsweetBall"));}
			if(choice<47403) {player.QuickSpawnItem(mod.ItemType("WimpodBall"));}
			if(choice<47543) {player.QuickSpawnItem(mod.ItemType("SandygastBall"));}
			if(choice<47588) {player.QuickSpawnItem(mod.ItemType("JangmooBall"));}
			if(choice<47843) {player.QuickSpawnItem(mod.ItemType("SkowvetBall"));}
			if(choice<48098) {player.QuickSpawnItem(mod.ItemType("RookideeBall"));}
			if(choice<48353) {player.QuickSpawnItem(mod.ItemType("BlipbugBall"));}
			if(choice<48608) {player.QuickSpawnItem(mod.ItemType("NickitBall"));}
			if(choice<48798) {player.QuickSpawnItem(mod.ItemType("GossifleurBall"));}
			if(choice<49053) {player.QuickSpawnItem(mod.ItemType("WoolooBall"));}
			if(choice<49308) {player.QuickSpawnItem(mod.ItemType("ChewtleBall"));}
			if(choice<49563) {player.QuickSpawnItem(mod.ItemType("YamperBall"));}
			if(choice<49818) {player.QuickSpawnItem(mod.ItemType("RolycolyBall"));}
			if(choice<50073) {player.QuickSpawnItem(mod.ItemType("ApplinBall"));}
			if(choice<50328) {player.QuickSpawnItem(mod.ItemType("SilicobraBall"));}
			if(choice<50583) {player.QuickSpawnItem(mod.ItemType("ArrokudaBall"));}
			if(choice<50773) {player.QuickSpawnItem(mod.ItemType("SizzlipedeBall"));}
			if(choice<50953) {player.QuickSpawnItem(mod.ItemType("ClobbopusBall"));}
			if(choice<51073) {player.QuickSpawnItem(mod.ItemType("SinisteaPhonyBall"));}
			if(choice<51193) {player.QuickSpawnItem(mod.ItemType("SinisteaAntiqueBall"));}
			if(choice<51428) {player.QuickSpawnItem(mod.ItemType("HatennaBall"));}
			if(choice<51683) {player.QuickSpawnItem(mod.ItemType("ImpidimpBall"));}
			if(choice<51883) {player.QuickSpawnItem(mod.ItemType("MilceryBall"));}
			if(choice<52073) {player.QuickSpawnItem(mod.ItemType("SnomBall"));}
			if(choice<52263) {player.QuickSpawnItem(mod.ItemType("CufantBall"));}
			if(choice<52308) {player.QuickSpawnItem(mod.ItemType("DreepyBall"));}

        }
	}
}
