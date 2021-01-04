using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Pokemmon.Items.PokeBoxes
{
	public class SportBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("SportBox");
			Tooltip.SetDefault("Contains a CAP Pokemon");
		}
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 22;
			item.useTime = 10;
			item.useAnimation = 10;
			//item.useStyle = 4;//Like Fallen Star
			item.value = 500000;
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
            int choice = Main.rand.Next(29);
			if(choice==0) {player.QuickSpawnItem(mod.ItemType("SyclarBall"));}
			if(choice==1) {player.QuickSpawnItem(mod.ItemType("RevenankhBall"));}
			if(choice==2) {player.QuickSpawnItem(mod.ItemType("EmbirchBall"));}
			if(choice==3) {player.QuickSpawnItem(mod.ItemType("BreeziBall"));}
			if(choice==4) {player.QuickSpawnItem(mod.ItemType("RebbleBall"));}
			if(choice==5) {player.QuickSpawnItem(mod.ItemType("PrivatykeBall"));}
			if(choice==6) {player.QuickSpawnItem(mod.ItemType("NohfaceBall"));}
			if(choice==7) {player.QuickSpawnItem(mod.ItemType("MonohmBall"));}
			if(choice==8) {player.QuickSpawnItem(mod.ItemType("ProtowattBall"));}
			if(choice==9) {player.QuickSpawnItem(mod.ItemType("VoodollBall"));}
			if(choice==10) {player.QuickSpawnItem(mod.ItemType("ScratchetBall"));}
			if(choice==11) {player.QuickSpawnItem(mod.ItemType("NecturineBall"));}
			if(choice==12) {player.QuickSpawnItem(mod.ItemType("MolluxBall"));}
			if(choice==13) {player.QuickSpawnItem(mod.ItemType("CupraBall"));}
			if(choice==14) {player.QuickSpawnItem(mod.ItemType("BrattlerBall"));}
			if(choice==15) {player.QuickSpawnItem(mod.ItemType("CawdetBall"));}
			if(choice==16) {player.QuickSpawnItem(mod.ItemType("VolkritterBall"));}
			if(choice==17) {player.QuickSpawnItem(mod.ItemType("SnugglowBall"));}
			if(choice==18) {player.QuickSpawnItem(mod.ItemType("FloatoyBall"));}
			if(choice==19) {player.QuickSpawnItem(mod.ItemType("CrucibelleBall"));}
			if(choice==20) {player.QuickSpawnItem(mod.ItemType("PluffleBall"));}
			if(choice==21) {player.QuickSpawnItem(mod.ItemType("PajantomBall"));}
			if(choice==22) {player.QuickSpawnItem(mod.ItemType("MumbaoBall"));}
			if(choice==23) {player.QuickSpawnItem(mod.ItemType("FawniferBall"));}
			if(choice==24) {player.QuickSpawnItem(mod.ItemType("SmogeckoBall"));}
			if(choice==25) {player.QuickSpawnItem(mod.ItemType("SwirlpoolBall"));}
			if(choice==26) {player.QuickSpawnItem(mod.ItemType("JustykeBall"));}
			if(choice==27) {player.QuickSpawnItem(mod.ItemType("SolotlBall"));}
			if(choice==28) {player.QuickSpawnItem(mod.ItemType("MiasmiteBall"));}

        }
	}
}
