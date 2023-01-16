using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Pokemmon.Items.PokeBoxes
{
	public class CherishBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("CherishBox");
			Tooltip.SetDefault("Contains a Mythical Pokemon");
		}
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 22;
			Item.useTime = 10;
			Item.useAnimation = 10;
			//Item.useStyle = ItemUseStyleID.HoldUp;//Like Fallen Star
			Item.value = 3000000;
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
            int choice = Main.rand.Next(23);
			if(choice==0) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MewBall").Type), Mod.Find<ModItem>("MewBall").Type);}
			if(choice==1) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CelebiBall").Type), Mod.Find<ModItem>("CelebiBall").Type);}
			if(choice==2) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("JirachiBall").Type), Mod.Find<ModItem>("JirachiBall").Type);}
			if(choice==3) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DeoxysBall").Type), Mod.Find<ModItem>("DeoxysBall").Type);}
			if(choice==4) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PhioneBall").Type), Mod.Find<ModItem>("PhioneBall").Type);}
			if(choice==5) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ManaphyBall").Type), Mod.Find<ModItem>("ManaphyBall").Type);}
			if(choice==6) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DarkraiBall").Type), Mod.Find<ModItem>("DarkraiBall").Type);}
			if(choice==7) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ShayminBall").Type), Mod.Find<ModItem>("ShayminBall").Type);}
			if(choice==8) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ArceusBall").Type), Mod.Find<ModItem>("ArceusBall").Type);}
			if(choice==9) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("VictiniBall").Type), Mod.Find<ModItem>("VictiniBall").Type);}
			if(choice==10) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("KeldeoBall").Type), Mod.Find<ModItem>("KeldeoBall").Type);}
			if(choice==11) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GenesectBall").Type), Mod.Find<ModItem>("GenesectBall").Type);}
			if(choice==12) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FloetteEternalFlowerBall").Type), Mod.Find<ModItem>("FloetteEternalFlowerBall").Type);}
			if(choice==13) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("DiancieBall").Type), Mod.Find<ModItem>("DiancieBall").Type);}
			if(choice==14) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("HoopaBall").Type), Mod.Find<ModItem>("HoopaBall").Type);}
			if(choice==15) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("VolcanionBall").Type), Mod.Find<ModItem>("VolcanionBall").Type);}
			if(choice==16) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TypeNullBall").Type), Mod.Find<ModItem>("TypeNullBall").Type);}
			if(choice==17) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MagearnaBall").Type), Mod.Find<ModItem>("MagearnaBall").Type);}
			if(choice==18) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MarshadowBall").Type), Mod.Find<ModItem>("MarshadowBall").Type);}
			if(choice==19) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ZeraoraBall").Type), Mod.Find<ModItem>("ZeraoraBall").Type);}
			if(choice==20) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MeltanBall").Type), Mod.Find<ModItem>("MeltanBall").Type);}
			if(choice==21) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("KubfuBall").Type), Mod.Find<ModItem>("KubfuBall").Type);}
			if(choice==22) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ZarudeBall").Type), Mod.Find<ModItem>("ZarudeBall").Type);}

        }
	}
}
