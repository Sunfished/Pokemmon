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
			Item.width = 22;
			Item.height = 22;
			Item.useTime = 10;
			Item.useAnimation = 10;
			//Item.useStyle = ItemUseStyleID.HoldUp;//Like Fallen Star
			Item.value = 500000;
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
            int choice = Main.rand.Next(29);
			if(choice==0) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SyclarBall").Type), Mod.Find<ModItem>("SyclarBall").Type);}
			if(choice==1) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RevenankhBall").Type), Mod.Find<ModItem>("RevenankhBall").Type);}
			if(choice==2) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("EmbirchBall").Type), Mod.Find<ModItem>("EmbirchBall").Type);}
			if(choice==3) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BreeziBall").Type), Mod.Find<ModItem>("BreeziBall").Type);}
			if(choice==4) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("RebbleBall").Type), Mod.Find<ModItem>("RebbleBall").Type);}
			if(choice==5) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PrivatykeBall").Type), Mod.Find<ModItem>("PrivatykeBall").Type);}
			if(choice==6) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("NohfaceBall").Type), Mod.Find<ModItem>("NohfaceBall").Type);}
			if(choice==7) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MonohmBall").Type), Mod.Find<ModItem>("MonohmBall").Type);}
			if(choice==8) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ProtowattBall").Type), Mod.Find<ModItem>("ProtowattBall").Type);}
			if(choice==9) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("VoodollBall").Type), Mod.Find<ModItem>("VoodollBall").Type);}
			if(choice==10) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("ScratchetBall").Type), Mod.Find<ModItem>("ScratchetBall").Type);}
			if(choice==11) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("NecturineBall").Type), Mod.Find<ModItem>("NecturineBall").Type);}
			if(choice==12) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MolluxBall").Type), Mod.Find<ModItem>("MolluxBall").Type);}
			if(choice==13) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CupraBall").Type), Mod.Find<ModItem>("CupraBall").Type);}
			if(choice==14) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("BrattlerBall").Type), Mod.Find<ModItem>("BrattlerBall").Type);}
			if(choice==15) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CawdetBall").Type), Mod.Find<ModItem>("CawdetBall").Type);}
			if(choice==16) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("VolkritterBall").Type), Mod.Find<ModItem>("VolkritterBall").Type);}
			if(choice==17) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SnugglowBall").Type), Mod.Find<ModItem>("SnugglowBall").Type);}
			if(choice==18) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FloatoyBall").Type), Mod.Find<ModItem>("FloatoyBall").Type);}
			if(choice==19) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("CrucibelleBall").Type), Mod.Find<ModItem>("CrucibelleBall").Type);}
			if(choice==20) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PluffleBall").Type), Mod.Find<ModItem>("PluffleBall").Type);}
			if(choice==21) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("PajantomBall").Type), Mod.Find<ModItem>("PajantomBall").Type);}
			if(choice==22) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MumbaoBall").Type), Mod.Find<ModItem>("MumbaoBall").Type);}
			if(choice==23) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("FawniferBall").Type), Mod.Find<ModItem>("FawniferBall").Type);}
			if(choice==24) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SmogeckoBall").Type), Mod.Find<ModItem>("SmogeckoBall").Type);}
			if(choice==25) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SwirlpoolBall").Type), Mod.Find<ModItem>("SwirlpoolBall").Type);}
			if(choice==26) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("JustykeBall").Type), Mod.Find<ModItem>("JustykeBall").Type);}
			if(choice==27) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("SolotlBall").Type), Mod.Find<ModItem>("SolotlBall").Type);}
			if(choice==28) {player.QuickSpawnItem(player.GetSource_OpenItem(Mod.Find<ModItem>("MiasmiteBall").Type), Mod.Find<ModItem>("MiasmiteBall").Type);}

        }
	}
}
