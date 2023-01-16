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
			Item.width = 22;
			Item.height = 22;
			Item.useTime = 10;
			Item.useAnimation = 10;
			//Item.useStyle = ItemUseStyleID.HoldUp;//Like Fallen Star
			Item.value = 100000;
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
            int choice = Main.rand.Next(18);
			if(choice==0) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PichuBall").Type), Mod.Find<ModItem>("PichuBall").Type);}
			if(choice==1) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CleffaBall").Type), Mod.Find<ModItem>("CleffaBall").Type);}
			if(choice==2) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("IgglybuffBall").Type), Mod.Find<ModItem>("IgglybuffBall").Type);}
			if(choice==3) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TogepiBall").Type), Mod.Find<ModItem>("TogepiBall").Type);}
			if(choice==4) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("TyrogueBall").Type), Mod.Find<ModItem>("TyrogueBall").Type);}
			if(choice==5) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SmoochumBall").Type), Mod.Find<ModItem>("SmoochumBall").Type);}
			if(choice==6) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ElekidBall").Type), Mod.Find<ModItem>("ElekidBall").Type);}
			if(choice==7) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MagbyBall").Type), Mod.Find<ModItem>("MagbyBall").Type);}
			if(choice==8) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("AzurillBall").Type), Mod.Find<ModItem>("AzurillBall").Type);}
			if(choice==9) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("WynautBall").Type), Mod.Find<ModItem>("WynautBall").Type);}
			if(choice==10) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BudewBall").Type), Mod.Find<ModItem>("BudewBall").Type);}
			if(choice==11) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ChinglingBall").Type), Mod.Find<ModItem>("ChinglingBall").Type);}
			if(choice==12) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BonslyBall").Type), Mod.Find<ModItem>("BonslyBall").Type);}
			if(choice==13) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MimeJrBall").Type), Mod.Find<ModItem>("MimeJrBall").Type);}
			if(choice==14) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("HappinyBall").Type), Mod.Find<ModItem>("HappinyBall").Type);}
			if(choice==15) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RioluBall").Type), Mod.Find<ModItem>("RioluBall").Type);}
			if(choice==16) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MantykeBall").Type), Mod.Find<ModItem>("MantykeBall").Type);}
			if(choice==17) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ToxelBall").Type), Mod.Find<ModItem>("ToxelBall").Type);}

        }
	}
}
