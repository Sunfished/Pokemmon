using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Pokemmon.Items.PokeBoxes
{
	public class PremierBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("PremierBox");
			Tooltip.SetDefault("Contains a Starter Pokemon");
		}
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.useTime = 10;
			Item.useAnimation = 10;
			//Item.useStyle = ItemUseStyleID.HoldUp;//Like Fallen Star
			Item.value = 200000;
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
            int choice = Main.rand.Next(26);
			if(choice==0) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BulbasaurBall").Type), Mod.Find<ModItem>("BulbasaurBall").Type);}
			if(choice==1) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CharmanderBall").Type), Mod.Find<ModItem>("CharmanderBall").Type);}
			if(choice==2) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SquirtleBall").Type), Mod.Find<ModItem>("SquirtleBall").Type);}
			if(choice==3) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PikachuPartnerBall").Type), Mod.Find<ModItem>("PikachuPartnerBall").Type);}
			if(choice==4) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("EeveePartnerBall").Type), Mod.Find<ModItem>("EeveePartnerBall").Type);}
			if(choice==5) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ChikoritaBall").Type), Mod.Find<ModItem>("ChikoritaBall").Type);}
			if(choice==6) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CyndaquilBall").Type), Mod.Find<ModItem>("CyndaquilBall").Type);}
			if(choice==7) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TotodileBall").Type), Mod.Find<ModItem>("TotodileBall").Type);}
			if(choice==8) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TreeckoBall").Type), Mod.Find<ModItem>("TreeckoBall").Type);}
			if(choice==9) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TorchicBall").Type), Mod.Find<ModItem>("TorchicBall").Type);}
			if(choice==10) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MudkipBall").Type), Mod.Find<ModItem>("MudkipBall").Type);}
			if(choice==11) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TurtwigBall").Type), Mod.Find<ModItem>("TurtwigBall").Type);}
			if(choice==12) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ChimcharBall").Type), Mod.Find<ModItem>("ChimcharBall").Type);}
			if(choice==13) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PiplupBall").Type), Mod.Find<ModItem>("PiplupBall").Type);}
			if(choice==14) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SnivyBall").Type), Mod.Find<ModItem>("SnivyBall").Type);}
			if(choice==15) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TepigBall").Type), Mod.Find<ModItem>("TepigBall").Type);}
			if(choice==16) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("OshawottBall").Type), Mod.Find<ModItem>("OshawottBall").Type);}
			if(choice==17) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ChespinBall").Type), Mod.Find<ModItem>("ChespinBall").Type);}
			if(choice==18) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FennekinBall").Type), Mod.Find<ModItem>("FennekinBall").Type);}
			if(choice==19) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FroakieBall").Type), Mod.Find<ModItem>("FroakieBall").Type);}
			if(choice==20) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RowletBall").Type), Mod.Find<ModItem>("RowletBall").Type);}
			if(choice==21) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("LittenBall").Type), Mod.Find<ModItem>("LittenBall").Type);}
			if(choice==22) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PopplioBall").Type), Mod.Find<ModItem>("PopplioBall").Type);}
			if(choice==23) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GrookeyBall").Type), Mod.Find<ModItem>("GrookeyBall").Type);}
			if(choice==24) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ScorbunnyBall").Type), Mod.Find<ModItem>("ScorbunnyBall").Type);}
			if(choice==25) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SobbleBall").Type), Mod.Find<ModItem>("SobbleBall").Type);}

        }
	}
}
