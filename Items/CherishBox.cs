using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Pokemmon.Items
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
			item.width = 22;
			item.height = 22;
			item.useTime = 10;
			item.useAnimation = 10;
			//item.useStyle = 4;//Like Fallen Star
			item.value = 3000000;
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
            int choice = Main.rand.Next(19);
			if(choice==0) {player.QuickSpawnItem(mod.ItemType("MewBall"));}
			if(choice==1) {player.QuickSpawnItem(mod.ItemType("CelebiBall"));}
			if(choice==2) {player.QuickSpawnItem(mod.ItemType("JirachiBall"));}
			if(choice==3) {player.QuickSpawnItem(mod.ItemType("DeoxysBall"));}
			if(choice==4) {player.QuickSpawnItem(mod.ItemType("PhioneBall"));}
			if(choice==5) {player.QuickSpawnItem(mod.ItemType("ManaphyBall"));}
			if(choice==6) {player.QuickSpawnItem(mod.ItemType("DarkraiBall"));}
			if(choice==7) {player.QuickSpawnItem(mod.ItemType("ShayminBall"));}
			if(choice==8) {player.QuickSpawnItem(mod.ItemType("ArceusBall"));}
			if(choice==9) {player.QuickSpawnItem(mod.ItemType("VictiniBall"));}
			if(choice==10) {player.QuickSpawnItem(mod.ItemType("KeldeoBall"));}
			if(choice==11) {player.QuickSpawnItem(mod.ItemType("GenesectBall"));}
			if(choice==12) {player.QuickSpawnItem(mod.ItemType("DiancieBall"));}
			if(choice==13) {player.QuickSpawnItem(mod.ItemType("HoopaBall"));}
			if(choice==14) {player.QuickSpawnItem(mod.ItemType("VolcanionBall"));}
			if(choice==15) {player.QuickSpawnItem(mod.ItemType("MagearnaBall"));}
			if(choice==16) {player.QuickSpawnItem(mod.ItemType("MarshadowBall"));}
			if(choice==17) {player.QuickSpawnItem(mod.ItemType("ZeraoraBall"));}
			if(choice==18) {player.QuickSpawnItem(mod.ItemType("MeltanBall"));}

        }
	}
}
