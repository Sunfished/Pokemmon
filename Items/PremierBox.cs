using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Pokemmon.Items
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
			item.width = 22;
			item.height = 22;
			item.useTime = 10;
			item.useAnimation = 10;
			//item.useStyle = 4;//Like Fallen Star
			item.value = 200000;
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
            int choice = Main.rand.Next(26);
			if(choice==0) {player.QuickSpawnItem(mod.ItemType("BulbasaurBall"));}
			if(choice==1) {player.QuickSpawnItem(mod.ItemType("CharmanderBall"));}
			if(choice==2) {player.QuickSpawnItem(mod.ItemType("SquirtleBall"));}
			if(choice==3) {player.QuickSpawnItem(mod.ItemType("PikachuPartnerBall"));}
			if(choice==4) {player.QuickSpawnItem(mod.ItemType("EeveePartnerBall"));}
			if(choice==5) {player.QuickSpawnItem(mod.ItemType("ChikoritaBall"));}
			if(choice==6) {player.QuickSpawnItem(mod.ItemType("CyndaquilBall"));}
			if(choice==7) {player.QuickSpawnItem(mod.ItemType("TotodileBall"));}
			if(choice==8) {player.QuickSpawnItem(mod.ItemType("TreeckoBall"));}
			if(choice==9) {player.QuickSpawnItem(mod.ItemType("TorchicBall"));}
			if(choice==10) {player.QuickSpawnItem(mod.ItemType("MudkipBall"));}
			if(choice==11) {player.QuickSpawnItem(mod.ItemType("TurtwigBall"));}
			if(choice==12) {player.QuickSpawnItem(mod.ItemType("ChimcharBall"));}
			if(choice==13) {player.QuickSpawnItem(mod.ItemType("PiplupBall"));}
			if(choice==14) {player.QuickSpawnItem(mod.ItemType("SnivyBall"));}
			if(choice==15) {player.QuickSpawnItem(mod.ItemType("TepigBall"));}
			if(choice==16) {player.QuickSpawnItem(mod.ItemType("OshawottBall"));}
			if(choice==17) {player.QuickSpawnItem(mod.ItemType("ChespinBall"));}
			if(choice==18) {player.QuickSpawnItem(mod.ItemType("FennekinBall"));}
			if(choice==19) {player.QuickSpawnItem(mod.ItemType("FroakieBall"));}
			if(choice==20) {player.QuickSpawnItem(mod.ItemType("RowletBall"));}
			if(choice==21) {player.QuickSpawnItem(mod.ItemType("LittenBall"));}
			if(choice==22) {player.QuickSpawnItem(mod.ItemType("PopplioBall"));}
			if(choice==23) {player.QuickSpawnItem(mod.ItemType("GrookeyBall"));}
			if(choice==24) {player.QuickSpawnItem(mod.ItemType("ScorbunnyBall"));}
			if(choice==25) {player.QuickSpawnItem(mod.ItemType("SobbleBall"));}

        }
	}
}
