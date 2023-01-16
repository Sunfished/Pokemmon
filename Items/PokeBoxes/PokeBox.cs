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
			Item.width = 22;
			Item.height = 22;
			Item.useTime = 10;
			Item.useAnimation = 10;
			//Item.useStyle = ItemUseStyleID.HoldUp;//Like Fallen Star
			Item.value = 350000;
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
            int choice = Main.rand.Next(52308);
			if(choice<255) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CaterpieBall").Type), Mod.Find<ModItem>("CaterpieBall").Type);}
			if(choice<510) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("WeedleBall").Type), Mod.Find<ModItem>("WeedleBall").Type);}
			if(choice<765) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PidgeyBall").Type), Mod.Find<ModItem>("PidgeyBall").Type);}
			if(choice<1020) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RattataBall").Type), Mod.Find<ModItem>("RattataBall").Type);}
			if(choice<1275) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RattataAlolaBall").Type), Mod.Find<ModItem>("RattataAlolaBall").Type);}
			if(choice<1530) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SpearowBall").Type), Mod.Find<ModItem>("SpearowBall").Type);}
			if(choice<1785) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("EkansBall").Type), Mod.Find<ModItem>("EkansBall").Type);}
			if(choice<2040) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SandshrewBall").Type), Mod.Find<ModItem>("SandshrewBall").Type);}
			if(choice<2295) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SandshrewAlolaBall").Type), Mod.Find<ModItem>("SandshrewAlolaBall").Type);}
			if(choice<2530) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("NidoranFBall").Type), Mod.Find<ModItem>("NidoranFBall").Type);}
			if(choice<2765) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("NidoranMBall").Type), Mod.Find<ModItem>("NidoranMBall").Type);}
			if(choice<2955) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("VulpixBall").Type), Mod.Find<ModItem>("VulpixBall").Type);}
			if(choice<3145) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("VulpixAlolaBall").Type), Mod.Find<ModItem>("VulpixAlolaBall").Type);}
			if(choice<3315) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("JigglypuffBall").Type), Mod.Find<ModItem>("JigglypuffBall").Type);}
			if(choice<3570) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ZubatBall").Type), Mod.Find<ModItem>("ZubatBall").Type);}
			if(choice<3825) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("OddishBall").Type), Mod.Find<ModItem>("OddishBall").Type);}
			if(choice<4015) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ParasBall").Type), Mod.Find<ModItem>("ParasBall").Type);}
			if(choice<4205) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("VenonatBall").Type), Mod.Find<ModItem>("VenonatBall").Type);}
			if(choice<4460) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DiglettBall").Type), Mod.Find<ModItem>("DiglettBall").Type);}
			if(choice<4715) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DiglettAlolaBall").Type), Mod.Find<ModItem>("DiglettAlolaBall").Type);}
			if(choice<4970) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MeowthBall").Type), Mod.Find<ModItem>("MeowthBall").Type);}
			if(choice<5225) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MeowthAlolaBall").Type), Mod.Find<ModItem>("MeowthAlolaBall").Type);}
			if(choice<5480) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MeowthGalarBall").Type), Mod.Find<ModItem>("MeowthGalarBall").Type);}
			if(choice<5670) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PsyduckBall").Type), Mod.Find<ModItem>("PsyduckBall").Type);}
			if(choice<5860) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MankeyBall").Type), Mod.Find<ModItem>("MankeyBall").Type);}
			if(choice<6050) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GrowlitheBall").Type), Mod.Find<ModItem>("GrowlitheBall").Type);}
			if(choice<6305) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PoliwagBall").Type), Mod.Find<ModItem>("PoliwagBall").Type);}
			if(choice<6505) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("AbraBall").Type), Mod.Find<ModItem>("AbraBall").Type);}
			if(choice<6685) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MachopBall").Type), Mod.Find<ModItem>("MachopBall").Type);}
			if(choice<6940) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BellsproutBall").Type), Mod.Find<ModItem>("BellsproutBall").Type);}
			if(choice<7130) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TentacoolBall").Type), Mod.Find<ModItem>("TentacoolBall").Type);}
			if(choice<7385) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GeodudeBall").Type), Mod.Find<ModItem>("GeodudeBall").Type);}
			if(choice<7640) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GeodudeAlolaBall").Type), Mod.Find<ModItem>("GeodudeAlolaBall").Type);}
			if(choice<7830) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PonytaBall").Type), Mod.Find<ModItem>("PonytaBall").Type);}
			if(choice<8020) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PonytaGalarBall").Type), Mod.Find<ModItem>("PonytaGalarBall").Type);}
			if(choice<8210) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SlowpokeBall").Type), Mod.Find<ModItem>("SlowpokeBall").Type);}
			if(choice<8400) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SlowpokeGalarBall").Type), Mod.Find<ModItem>("SlowpokeGalarBall").Type);}
			if(choice<8590) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MagnemiteBall").Type), Mod.Find<ModItem>("MagnemiteBall").Type);}
			if(choice<8635) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FarfetchdGalarBall").Type), Mod.Find<ModItem>("FarfetchdGalarBall").Type);}
			if(choice<8825) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DoduoBall").Type), Mod.Find<ModItem>("DoduoBall").Type);}
			if(choice<9015) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SeelBall").Type), Mod.Find<ModItem>("SeelBall").Type);}
			if(choice<9205) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GrimerBall").Type), Mod.Find<ModItem>("GrimerBall").Type);}
			if(choice<9395) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GrimerAlolaBall").Type), Mod.Find<ModItem>("GrimerAlolaBall").Type);}
			if(choice<9585) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ShellderBall").Type), Mod.Find<ModItem>("ShellderBall").Type);}
			if(choice<9775) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GastlyBall").Type), Mod.Find<ModItem>("GastlyBall").Type);}
			if(choice<9820) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("OnixBall").Type), Mod.Find<ModItem>("OnixBall").Type);}
			if(choice<10010) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DrowzeeBall").Type), Mod.Find<ModItem>("DrowzeeBall").Type);}
			if(choice<10235) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("KrabbyBall").Type), Mod.Find<ModItem>("KrabbyBall").Type);}
			if(choice<10425) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("VoltorbBall").Type), Mod.Find<ModItem>("VoltorbBall").Type);}
			if(choice<10515) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ExeggcuteBall").Type), Mod.Find<ModItem>("ExeggcuteBall").Type);}
			if(choice<10705) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CuboneBall").Type), Mod.Find<ModItem>("CuboneBall").Type);}
			if(choice<10750) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("LickitungBall").Type), Mod.Find<ModItem>("LickitungBall").Type);}
			if(choice<10940) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("KoffingBall").Type), Mod.Find<ModItem>("KoffingBall").Type);}
			if(choice<11060) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RhyhornBall").Type), Mod.Find<ModItem>("RhyhornBall").Type);}
			if(choice<11105) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TangelaBall").Type), Mod.Find<ModItem>("TangelaBall").Type);}
			if(choice<11330) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("HorseaBall").Type), Mod.Find<ModItem>("HorseaBall").Type);}
			if(choice<11555) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GoldeenBall").Type), Mod.Find<ModItem>("GoldeenBall").Type);}
			if(choice<11780) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("StaryuBall").Type), Mod.Find<ModItem>("StaryuBall").Type);}
			if(choice<11825) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ScytherBall").Type), Mod.Find<ModItem>("ScytherBall").Type);}
			if(choice<12080) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MagikarpBall").Type), Mod.Find<ModItem>("MagikarpBall").Type);}
			if(choice<12125) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("EeveeBall").Type), Mod.Find<ModItem>("EeveeBall").Type);}
			if(choice<12170) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PorygonBall").Type), Mod.Find<ModItem>("PorygonBall").Type);}
			if(choice<12215) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DratiniBall").Type), Mod.Find<ModItem>("DratiniBall").Type);}
			if(choice<12470) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SentretBall").Type), Mod.Find<ModItem>("SentretBall").Type);}
			if(choice<12725) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("HoothootBall").Type), Mod.Find<ModItem>("HoothootBall").Type);}
			if(choice<12980) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("LedybaBall").Type), Mod.Find<ModItem>("LedybaBall").Type);}
			if(choice<13235) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SpinarakBall").Type), Mod.Find<ModItem>("SpinarakBall").Type);}
			if(choice<13425) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ChinchouBall").Type), Mod.Find<ModItem>("ChinchouBall").Type);}
			if(choice<13615) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("NatuBall").Type), Mod.Find<ModItem>("NatuBall").Type);}
			if(choice<13850) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MareepBall").Type), Mod.Find<ModItem>("MareepBall").Type);}
			if(choice<14105) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("HoppipBall").Type), Mod.Find<ModItem>("HoppipBall").Type);}
			if(choice<14150) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("AipomBall").Type), Mod.Find<ModItem>("AipomBall").Type);}
			if(choice<14385) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SunkernBall").Type), Mod.Find<ModItem>("SunkernBall").Type);}
			if(choice<14460) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("YanmaBall").Type), Mod.Find<ModItem>("YanmaBall").Type);}
			if(choice<14715) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("WooperBall").Type), Mod.Find<ModItem>("WooperBall").Type);}
			if(choice<14745) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MurkrowBall").Type), Mod.Find<ModItem>("MurkrowBall").Type);}
			if(choice<14790) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MisdreavusBall").Type), Mod.Find<ModItem>("MisdreavusBall").Type);}
			if(choice<14980) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PinecoBall").Type), Mod.Find<ModItem>("PinecoBall").Type);}
			if(choice<15040) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GligarBall").Type), Mod.Find<ModItem>("GligarBall").Type);}
			if(choice<15230) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SnubbullBall").Type), Mod.Find<ModItem>("SnubbullBall").Type);}
			if(choice<15290) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SneaselBall").Type), Mod.Find<ModItem>("SneaselBall").Type);}
			if(choice<15410) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TeddiursaBall").Type), Mod.Find<ModItem>("TeddiursaBall").Type);}
			if(choice<15600) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SlugmaBall").Type), Mod.Find<ModItem>("SlugmaBall").Type);}
			if(choice<15825) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SwinubBall").Type), Mod.Find<ModItem>("SwinubBall").Type);}
			if(choice<15885) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CorsolaGalarBall").Type), Mod.Find<ModItem>("CorsolaGalarBall").Type);}
			if(choice<16075) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RemoraidBall").Type), Mod.Find<ModItem>("RemoraidBall").Type);}
			if(choice<16195) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("HoundourBall").Type), Mod.Find<ModItem>("HoundourBall").Type);}
			if(choice<16315) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PhanpyBall").Type), Mod.Find<ModItem>("PhanpyBall").Type);}
			if(choice<16360) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("LarvitarBall").Type), Mod.Find<ModItem>("LarvitarBall").Type);}
			if(choice<16615) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PoochyenaBall").Type), Mod.Find<ModItem>("PoochyenaBall").Type);}
			if(choice<16870) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ZigzagoonBall").Type), Mod.Find<ModItem>("ZigzagoonBall").Type);}
			if(choice<17125) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ZigzagoonGalarBall").Type), Mod.Find<ModItem>("ZigzagoonGalarBall").Type);}
			if(choice<17380) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("WurmpleBall").Type), Mod.Find<ModItem>("WurmpleBall").Type);}
			if(choice<17635) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("LotadBall").Type), Mod.Find<ModItem>("LotadBall").Type);}
			if(choice<17890) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SeedotBall").Type), Mod.Find<ModItem>("SeedotBall").Type);}
			if(choice<18090) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TaillowBall").Type), Mod.Find<ModItem>("TaillowBall").Type);}
			if(choice<18280) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("WingullBall").Type), Mod.Find<ModItem>("WingullBall").Type);}
			if(choice<18515) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RaltsBall").Type), Mod.Find<ModItem>("RaltsBall").Type);}
			if(choice<18715) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SurskitBall").Type), Mod.Find<ModItem>("SurskitBall").Type);}
			if(choice<18970) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ShroomishBall").Type), Mod.Find<ModItem>("ShroomishBall").Type);}
			if(choice<19225) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SlakothBall").Type), Mod.Find<ModItem>("SlakothBall").Type);}
			if(choice<19480) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("NincadaBall").Type), Mod.Find<ModItem>("NincadaBall").Type);}
			if(choice<19670) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("WhismurBall").Type), Mod.Find<ModItem>("WhismurBall").Type);}
			if(choice<19850) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MakuhitaBall").Type), Mod.Find<ModItem>("MakuhitaBall").Type);}
			if(choice<20105) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("NosepassBall").Type), Mod.Find<ModItem>("NosepassBall").Type);}
			if(choice<20360) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SkittyBall").Type), Mod.Find<ModItem>("SkittyBall").Type);}
			if(choice<20540) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("AronBall").Type), Mod.Find<ModItem>("AronBall").Type);}
			if(choice<20720) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MedititeBall").Type), Mod.Find<ModItem>("MedititeBall").Type);}
			if(choice<20840) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ElectrikeBall").Type), Mod.Find<ModItem>("ElectrikeBall").Type);}
			if(choice<21065) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GulpinBall").Type), Mod.Find<ModItem>("GulpinBall").Type);}
			if(choice<21290) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CarvanhaBall").Type), Mod.Find<ModItem>("CarvanhaBall").Type);}
			if(choice<21415) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("WailmerBall").Type), Mod.Find<ModItem>("WailmerBall").Type);}
			if(choice<21670) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("NumelBall").Type), Mod.Find<ModItem>("NumelBall").Type);}
			if(choice<21925) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SpoinkBall").Type), Mod.Find<ModItem>("SpoinkBall").Type);}
			if(choice<22180) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TrapinchBall").Type), Mod.Find<ModItem>("TrapinchBall").Type);}
			if(choice<22370) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CacneaBall").Type), Mod.Find<ModItem>("CacneaBall").Type);}
			if(choice<22625) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SwabluBall").Type), Mod.Find<ModItem>("SwabluBall").Type);}
			if(choice<22815) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BarboachBall").Type), Mod.Find<ModItem>("BarboachBall").Type);}
			if(choice<23020) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CorphishBall").Type), Mod.Find<ModItem>("CorphishBall").Type);}
			if(choice<23275) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BaltoyBall").Type), Mod.Find<ModItem>("BaltoyBall").Type);}
			if(choice<23530) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FeebasBall").Type), Mod.Find<ModItem>("FeebasBall").Type);}
			if(choice<23755) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ShuppetBall").Type), Mod.Find<ModItem>("ShuppetBall").Type);}
			if(choice<23945) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DuskullBall").Type), Mod.Find<ModItem>("DuskullBall").Type);}
			if(choice<24135) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SnoruntBall").Type), Mod.Find<ModItem>("SnoruntBall").Type);}
			if(choice<24390) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SphealBall").Type), Mod.Find<ModItem>("SphealBall").Type);}
			if(choice<24645) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ClamperlBall").Type), Mod.Find<ModItem>("ClamperlBall").Type);}
			if(choice<24690) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BagonBall").Type), Mod.Find<ModItem>("BagonBall").Type);}
			if(choice<24693) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BeldumBall").Type), Mod.Find<ModItem>("BeldumBall").Type);}
			if(choice<24948) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("StarlyBall").Type), Mod.Find<ModItem>("StarlyBall").Type);}
			if(choice<25203) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BidoofBall").Type), Mod.Find<ModItem>("BidoofBall").Type);}
			if(choice<25458) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("KricketotBall").Type), Mod.Find<ModItem>("KricketotBall").Type);}
			if(choice<25693) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ShinxBall").Type), Mod.Find<ModItem>("ShinxBall").Type);}
			if(choice<25813) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BurmyPlantCloakBall").Type), Mod.Find<ModItem>("BurmyPlantCloakBall").Type);}
			if(choice<25933) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BurmySandyCloakBall").Type), Mod.Find<ModItem>("BurmySandyCloakBall").Type);}
			if(choice<26053) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BurmyTrashCloakBall").Type), Mod.Find<ModItem>("BurmyTrashCloakBall").Type);}
			if(choice<26173) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CombeeBall").Type), Mod.Find<ModItem>("CombeeBall").Type);}
			if(choice<26363) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BuizelBall").Type), Mod.Find<ModItem>("BuizelBall").Type);}
			if(choice<26553) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CherubiBall").Type), Mod.Find<ModItem>("CherubiBall").Type);}
			if(choice<26743) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ShellosWestSeaBall").Type), Mod.Find<ModItem>("ShellosWestSeaBall").Type);}
			if(choice<26933) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ShellosEastSeaBall").Type), Mod.Find<ModItem>("ShellosEastSeaBall").Type);}
			if(choice<27058) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DrifloonBall").Type), Mod.Find<ModItem>("DrifloonBall").Type);}
			if(choice<27248) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BunearyBall").Type), Mod.Find<ModItem>("BunearyBall").Type);}
			if(choice<27438) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GlameowBall").Type), Mod.Find<ModItem>("GlameowBall").Type);}
			if(choice<27663) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("StunkyBall").Type), Mod.Find<ModItem>("StunkyBall").Type);}
			if(choice<27918) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BronzorBall").Type), Mod.Find<ModItem>("BronzorBall").Type);}
			if(choice<27963) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GibleBall").Type), Mod.Find<ModItem>("GibleBall").Type);}
			if(choice<28013) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MunchlaxBall").Type), Mod.Find<ModItem>("MunchlaxBall").Type);}
			if(choice<28153) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("HippopotasBall").Type), Mod.Find<ModItem>("HippopotasBall").Type);}
			if(choice<28273) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SkorupiBall").Type), Mod.Find<ModItem>("SkorupiBall").Type);}
			if(choice<28413) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CroagunkBall").Type), Mod.Find<ModItem>("CroagunkBall").Type);}
			if(choice<28603) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FinneonBall").Type), Mod.Find<ModItem>("FinneonBall").Type);}
			if(choice<28723) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SnoverBall").Type), Mod.Find<ModItem>("SnoverBall").Type);}
			if(choice<28978) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PatratBall").Type), Mod.Find<ModItem>("PatratBall").Type);}
			if(choice<29233) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("LillipupBall").Type), Mod.Find<ModItem>("LillipupBall").Type);}
			if(choice<29488) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PurrloinBall").Type), Mod.Find<ModItem>("PurrloinBall").Type);}
			if(choice<29678) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PansageBall").Type), Mod.Find<ModItem>("PansageBall").Type);}
			if(choice<29868) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PansearBall").Type), Mod.Find<ModItem>("PansearBall").Type);}
			if(choice<30058) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PanpourBall").Type), Mod.Find<ModItem>("PanpourBall").Type);}
			if(choice<30248) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MunnaBall").Type), Mod.Find<ModItem>("MunnaBall").Type);}
			if(choice<30503) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PidoveBall").Type), Mod.Find<ModItem>("PidoveBall").Type);}
			if(choice<30693) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BlitzleBall").Type), Mod.Find<ModItem>("BlitzleBall").Type);}
			if(choice<30948) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RoggenrolaBall").Type), Mod.Find<ModItem>("RoggenrolaBall").Type);}
			if(choice<31138) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("WoobatBall").Type), Mod.Find<ModItem>("WoobatBall").Type);}
			if(choice<31258) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DrilburBall").Type), Mod.Find<ModItem>("DrilburBall").Type);}
			if(choice<31438) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TimburrBall").Type), Mod.Find<ModItem>("TimburrBall").Type);}
			if(choice<31693) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TympoleBall").Type), Mod.Find<ModItem>("TympoleBall").Type);}
			if(choice<31948) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SewaddleBall").Type), Mod.Find<ModItem>("SewaddleBall").Type);}
			if(choice<32203) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("VenipedeBall").Type), Mod.Find<ModItem>("VenipedeBall").Type);}
			if(choice<32393) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CottoneeBall").Type), Mod.Find<ModItem>("CottoneeBall").Type);}
			if(choice<32583) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PetililBall").Type), Mod.Find<ModItem>("PetililBall").Type);}
			if(choice<32763) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SandileBall").Type), Mod.Find<ModItem>("SandileBall").Type);}
			if(choice<32883) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DarumakaBall").Type), Mod.Find<ModItem>("DarumakaBall").Type);}
			if(choice<33003) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DarumakaGalarBall").Type), Mod.Find<ModItem>("DarumakaGalarBall").Type);}
			if(choice<33193) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DwebbleBall").Type), Mod.Find<ModItem>("DwebbleBall").Type);}
			if(choice<33373) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ScraggyBall").Type), Mod.Find<ModItem>("ScraggyBall").Type);}
			if(choice<33563) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("YamaskBall").Type), Mod.Find<ModItem>("YamaskBall").Type);}
			if(choice<33753) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("YamaskGalarBall").Type), Mod.Find<ModItem>("YamaskGalarBall").Type);}
			if(choice<33943) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TrubbishBall").Type), Mod.Find<ModItem>("TrubbishBall").Type);}
			if(choice<34018) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ZoruaBall").Type), Mod.Find<ModItem>("ZoruaBall").Type);}
			if(choice<34273) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MinccinoBall").Type), Mod.Find<ModItem>("MinccinoBall").Type);}
			if(choice<34473) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GothitaBall").Type), Mod.Find<ModItem>("GothitaBall").Type);}
			if(choice<34673) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SolosisBall").Type), Mod.Find<ModItem>("SolosisBall").Type);}
			if(choice<34863) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DucklettBall").Type), Mod.Find<ModItem>("DucklettBall").Type);}
			if(choice<35118) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("VanilliteBall").Type), Mod.Find<ModItem>("VanilliteBall").Type);}
			if(choice<35308) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DeerlingSpringBall").Type), Mod.Find<ModItem>("DeerlingSpringBall").Type);}
			if(choice<35498) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DeerlingSummerBall").Type), Mod.Find<ModItem>("DeerlingSummerBall").Type);}
			if(choice<35688) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DeerlingAutumnBall").Type), Mod.Find<ModItem>("DeerlingAutumnBall").Type);}
			if(choice<35878) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DeerlingWinterBall").Type), Mod.Find<ModItem>("DeerlingWinterBall").Type);}
			if(choice<36078) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("KarrablastBall").Type), Mod.Find<ModItem>("KarrablastBall").Type);}
			if(choice<36268) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FoongusBall").Type), Mod.Find<ModItem>("FoongusBall").Type);}
			if(choice<36458) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FrillishMBall").Type), Mod.Find<ModItem>("FrillishMBall").Type);}
			if(choice<36648) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FrillishFBall").Type), Mod.Find<ModItem>("FrillishFBall").Type);}
			if(choice<36838) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("JoltikBall").Type), Mod.Find<ModItem>("JoltikBall").Type);}
			if(choice<37093) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FerroseedBall").Type), Mod.Find<ModItem>("FerroseedBall").Type);}
			if(choice<37223) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("KlinkBall").Type), Mod.Find<ModItem>("KlinkBall").Type);}
			if(choice<37413) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TynamoBall").Type), Mod.Find<ModItem>("TynamoBall").Type);}
			if(choice<37668) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ElgyemBall").Type), Mod.Find<ModItem>("ElgyemBall").Type);}
			if(choice<37858) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("LitwickBall").Type), Mod.Find<ModItem>("LitwickBall").Type);}
			if(choice<37933) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("AxewBall").Type), Mod.Find<ModItem>("AxewBall").Type);}
			if(choice<38053) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CubchooBall").Type), Mod.Find<ModItem>("CubchooBall").Type);}
			if(choice<38253) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ShelmetBall").Type), Mod.Find<ModItem>("ShelmetBall").Type);}
			if(choice<38433) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MienfooBall").Type), Mod.Find<ModItem>("MienfooBall").Type);}
			if(choice<38623) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GolettBall").Type), Mod.Find<ModItem>("GolettBall").Type);}
			if(choice<38743) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PawniardBall").Type), Mod.Find<ModItem>("PawniardBall").Type);}
			if(choice<38933) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RuffletBall").Type), Mod.Find<ModItem>("RuffletBall").Type);}
			if(choice<39123) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("VullabyBall").Type), Mod.Find<ModItem>("VullabyBall").Type);}
			if(choice<39168) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DeinoBall").Type), Mod.Find<ModItem>("DeinoBall").Type);}
			if(choice<39213) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("LarvestaBall").Type), Mod.Find<ModItem>("LarvestaBall").Type);}
			if(choice<39468) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BunnelbyBall").Type), Mod.Find<ModItem>("BunnelbyBall").Type);}
			if(choice<39723) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FletchlingBall").Type), Mod.Find<ModItem>("FletchlingBall").Type);}
			if(choice<39978) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ScatterbugBall").Type), Mod.Find<ModItem>("ScatterbugBall").Type);}
			if(choice<40198) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("LitleoBall").Type), Mod.Find<ModItem>("LitleoBall").Type);}
			if(choice<40423) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FlabebeRedFlowerBall").Type), Mod.Find<ModItem>("FlabebeRedFlowerBall").Type);}
			if(choice<40648) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FlabebeYellowFlowerBall").Type), Mod.Find<ModItem>("FlabebeYellowFlowerBall").Type);}
			if(choice<40873) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FlabebeOrangeFlowerBall").Type), Mod.Find<ModItem>("FlabebeOrangeFlowerBall").Type);}
			if(choice<41098) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FlabebeBlueFlowerBall").Type), Mod.Find<ModItem>("FlabebeBlueFlowerBall").Type);}
			if(choice<41323) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FlabebeWhiteFlowerBall").Type), Mod.Find<ModItem>("FlabebeWhiteFlowerBall").Type);}
			if(choice<41523) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SkiddoBall").Type), Mod.Find<ModItem>("SkiddoBall").Type);}
			if(choice<41743) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PanchamBall").Type), Mod.Find<ModItem>("PanchamBall").Type);}
			if(choice<41933) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("EspurrBall").Type), Mod.Find<ModItem>("EspurrBall").Type);}
			if(choice<42113) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("HonedgeBall").Type), Mod.Find<ModItem>("HonedgeBall").Type);}
			if(choice<42313) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SpritzeeBall").Type), Mod.Find<ModItem>("SpritzeeBall").Type);}
			if(choice<42513) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SwirlixBall").Type), Mod.Find<ModItem>("SwirlixBall").Type);}
			if(choice<42703) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("InkayBall").Type), Mod.Find<ModItem>("InkayBall").Type);}
			if(choice<42823) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BinacleBall").Type), Mod.Find<ModItem>("BinacleBall").Type);}
			if(choice<43048) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SkrelpBall").Type), Mod.Find<ModItem>("SkrelpBall").Type);}
			if(choice<43273) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ClauncherBall").Type), Mod.Find<ModItem>("ClauncherBall").Type);}
			if(choice<43463) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("HelioptileBall").Type), Mod.Find<ModItem>("HelioptileBall").Type);}
			if(choice<43508) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GoomyBall").Type), Mod.Find<ModItem>("GoomyBall").Type);}
			if(choice<43628) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PhantumpBall").Type), Mod.Find<ModItem>("PhantumpBall").Type);}
			if(choice<43748) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PumpkabooSmallSizeBall").Type), Mod.Find<ModItem>("PumpkabooSmallSizeBall").Type);}
			if(choice<43868) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PumpkabooAverageSizeBall").Type), Mod.Find<ModItem>("PumpkabooAverageSizeBall").Type);}
			if(choice<43988) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PumpkabooLargeSizeBall").Type), Mod.Find<ModItem>("PumpkabooLargeSizeBall").Type);}
			if(choice<44108) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PumpkabooSuperSizeBall").Type), Mod.Find<ModItem>("PumpkabooSuperSizeBall").Type);}
			if(choice<44298) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BergmiteBall").Type), Mod.Find<ModItem>("BergmiteBall").Type);}
			if(choice<44488) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("NoibatBall").Type), Mod.Find<ModItem>("NoibatBall").Type);}
			if(choice<44743) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PikipekBall").Type), Mod.Find<ModItem>("PikipekBall").Type);}
			if(choice<44998) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("YungoosBall").Type), Mod.Find<ModItem>("YungoosBall").Type);}
			if(choice<45253) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GrubbinBall").Type), Mod.Find<ModItem>("GrubbinBall").Type);}
			if(choice<45478) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CrabrawlerBall").Type), Mod.Find<ModItem>("CrabrawlerBall").Type);}
			if(choice<45668) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CutieflyBall").Type), Mod.Find<ModItem>("CutieflyBall").Type);}
			if(choice<45858) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RockruffBall").Type), Mod.Find<ModItem>("RockruffBall").Type);}
			if(choice<46048) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MareanieBall").Type), Mod.Find<ModItem>("MareanieBall").Type);}
			if(choice<46238) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MudbrayBall").Type), Mod.Find<ModItem>("MudbrayBall").Type);}
			if(choice<46438) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DewpiderBall").Type), Mod.Find<ModItem>("DewpiderBall").Type);}
			if(choice<46628) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FomantisBall").Type), Mod.Find<ModItem>("FomantisBall").Type);}
			if(choice<46818) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MorelullBall").Type), Mod.Find<ModItem>("MorelullBall").Type);}
			if(choice<46938) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SalanditBall").Type), Mod.Find<ModItem>("SalanditBall").Type);}
			if(choice<47078) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("StuffulBall").Type), Mod.Find<ModItem>("StuffulBall").Type);}
			if(choice<47313) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BounsweetBall").Type), Mod.Find<ModItem>("BounsweetBall").Type);}
			if(choice<47403) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("WimpodBall").Type), Mod.Find<ModItem>("WimpodBall").Type);}
			if(choice<47543) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SandygastBall").Type), Mod.Find<ModItem>("SandygastBall").Type);}
			if(choice<47588) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("JangmooBall").Type), Mod.Find<ModItem>("JangmooBall").Type);}
			if(choice<47843) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SkowvetBall").Type), Mod.Find<ModItem>("SkowvetBall").Type);}
			if(choice<48098) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RookideeBall").Type), Mod.Find<ModItem>("RookideeBall").Type);}
			if(choice<48353) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BlipbugBall").Type), Mod.Find<ModItem>("BlipbugBall").Type);}
			if(choice<48608) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("NickitBall").Type), Mod.Find<ModItem>("NickitBall").Type);}
			if(choice<48798) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GossifleurBall").Type), Mod.Find<ModItem>("GossifleurBall").Type);}
			if(choice<49053) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("WoolooBall").Type), Mod.Find<ModItem>("WoolooBall").Type);}
			if(choice<49308) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ChewtleBall").Type), Mod.Find<ModItem>("ChewtleBall").Type);}
			if(choice<49563) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("YamperBall").Type), Mod.Find<ModItem>("YamperBall").Type);}
			if(choice<49818) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RolycolyBall").Type), Mod.Find<ModItem>("RolycolyBall").Type);}
			if(choice<50073) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ApplinBall").Type), Mod.Find<ModItem>("ApplinBall").Type);}
			if(choice<50328) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SilicobraBall").Type), Mod.Find<ModItem>("SilicobraBall").Type);}
			if(choice<50583) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ArrokudaBall").Type), Mod.Find<ModItem>("ArrokudaBall").Type);}
			if(choice<50773) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SizzlipedeBall").Type), Mod.Find<ModItem>("SizzlipedeBall").Type);}
			if(choice<50953) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ClobbopusBall").Type), Mod.Find<ModItem>("ClobbopusBall").Type);}
			if(choice<51073) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SinisteaPhonyBall").Type), Mod.Find<ModItem>("SinisteaPhonyBall").Type);}
			if(choice<51193) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SinisteaAntiqueBall").Type), Mod.Find<ModItem>("SinisteaAntiqueBall").Type);}
			if(choice<51428) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("HatennaBall").Type), Mod.Find<ModItem>("HatennaBall").Type);}
			if(choice<51683) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ImpidimpBall").Type), Mod.Find<ModItem>("ImpidimpBall").Type);}
			if(choice<51883) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MilceryBall").Type), Mod.Find<ModItem>("MilceryBall").Type);}
			if(choice<52073) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SnomBall").Type), Mod.Find<ModItem>("SnomBall").Type);}
			if(choice<52263) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CufantBall").Type), Mod.Find<ModItem>("CufantBall").Type);}
			if(choice<52308) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DreepyBall").Type), Mod.Find<ModItem>("DreepyBall").Type);}

        }
	}
}
