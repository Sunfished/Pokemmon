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
			Item.width = 22;
			Item.height = 22;
			Item.useTime = 10;
			Item.useAnimation = 10;
			//Item.useStyle = ItemUseStyleID.HoldUp;//Like Fallen Star
			Item.value = 1000000;
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
            int choice = Main.rand.Next(10);
			if(choice==0) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("NihilegoBall").Type), Mod.Find<ModItem>("NihilegoBall").Type);}
			if(choice==1) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BuzzwoleBall").Type), Mod.Find<ModItem>("BuzzwoleBall").Type);}
			if(choice==2) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PheromosaBall").Type), Mod.Find<ModItem>("PheromosaBall").Type);}
			if(choice==3) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("XurkitreeBall").Type), Mod.Find<ModItem>("XurkitreeBall").Type);}
			if(choice==4) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CelesteelaBall").Type), Mod.Find<ModItem>("CelesteelaBall").Type);}
			if(choice==5) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("KartanaBall").Type), Mod.Find<ModItem>("KartanaBall").Type);}
			if(choice==6) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("GuzzlordBall").Type), Mod.Find<ModItem>("GuzzlordBall").Type);}
			if(choice==7) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PoipoleBall").Type), Mod.Find<ModItem>("PoipoleBall").Type);}
			if(choice==8) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("StakatakaBall").Type), Mod.Find<ModItem>("StakatakaBall").Type);}
			if(choice==9) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BlacephalonBall").Type), Mod.Find<ModItem>("BlacephalonBall").Type);}

        }
	}
}
