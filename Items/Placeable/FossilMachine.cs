using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items.Placeable
{
	public class FossilMachine : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Fossil Machine");
			Tooltip.SetDefault("Used to Revive Fossil Pokemon");
		}

		public override void SetDefaults() {
			Item.width = 40;
			Item.height = 41;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.value = 150000;
			Item.createTile = Mod.Find<ModTile>("FossilMachine").Type;
		}

		public override void AddRecipes() {
			
			//Craft Itself
			Recipe recipe = CreateRecipe();
			recipe.AddTile(TileID.Anvils);
			recipe.AddIngredient(ItemID.IronBar, 20);
			recipe.Register();
			
			Recipe recipe2 = CreateRecipe();
			recipe2.AddTile(TileID.Anvils);
			recipe2.AddIngredient(ItemID.LeadBar, 20);
			recipe2.Register();
			
			//Gen 1 Fossils
			//Recipe recipeA = Recipe.Create(Mod.Find<ModItem>("OmanyteBall").Type);
            Recipe recipeA = Recipe.Create(Mod.Find<ModItem>("OmanyteBall").Type);
            recipeA.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			recipeA.AddIngredient(Mod,"ItemHelixFossil");
			recipeA.AddIngredient(Mod,"ItemExpCandyS");
			recipeA.Register();
			
			Recipe recipeB = Recipe.Create(Mod.Find<ModItem>("KabutoBall").Type);
			recipeB.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			recipeB.AddIngredient(Mod,"ItemDomeFossil");;
			recipeB.AddIngredient(Mod,"ItemExpCandyS");;
			recipeB.Register();
			
			Recipe recipec = Recipe.Create(Mod.Find<ModItem>("AerodactylBall").Type);
			recipec.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			recipec.AddIngredient(Mod,"ItemOldAmber");;
			recipec.AddIngredient(Mod,"ItemExpCandyL");;
			recipec.Register();
			
			//Gen 3 Fossils
			Recipe reciped = Recipe.Create(Mod.Find<ModItem>("AnorithBall").Type);
			reciped.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			reciped.AddIngredient(Mod,"ItemClawFossil");;
			reciped.AddIngredient(Mod,"ItemExpCandyS");;
			reciped.Register();
			
			Recipe recipee = Recipe.Create(Mod.Find<ModItem>("LileepBall").Type);
			recipee.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			recipee.AddIngredient(Mod,"ItemRootFossil");;
			recipee.AddIngredient(Mod,"ItemExpCandyS");;
			recipee.Register();
			
			//Gen 4 Fossils
			Recipe recipef = Recipe.Create(Mod.Find<ModItem>("ShieldonBall").Type);
			recipef.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			recipef.AddIngredient(Mod,"ItemArmorFossil");;
			recipef.AddIngredient(Mod,"ItemExpCandyS");;
			recipef.Register();
			
			Recipe recipeg = Recipe.Create(Mod.Find<ModItem>("CranidosBall").Type);
			recipeg.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			recipeg.AddIngredient(Mod,"ItemSkullFossil");;
			recipeg.AddIngredient(Mod,"ItemExpCandyS");;
			recipeg.Register();
			
			//Gen 5 Fossils
			Recipe recipeh = Recipe.Create(Mod.Find<ModItem>("ArchenBall").Type);
			recipeh.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			recipeh.AddIngredient(Mod,"ItemPlumeFossil");;
			recipeh.AddIngredient(Mod,"ItemExpCandyS");;
			recipeh.Register();
			
			Recipe recipei = Recipe.Create(Mod.Find<ModItem>("TirtougaBall").Type);
			recipei.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			recipei.AddIngredient(Mod,"ItemCoverFossil");;
			recipei.AddIngredient(Mod,"ItemExpCandyS");;
			recipei.Register();
			
			//Gen 6 Fossils
			Recipe recipej = Recipe.Create(Mod.Find<ModItem>("AmauraBall").Type);
			recipej.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			recipej.AddIngredient(Mod,"ItemSailFossil");;
			recipej.AddIngredient(Mod,"ItemExpCandyS");;
			recipej.Register();
			
			Recipe recipek = Recipe.Create(Mod.Find<ModItem>("TyruntBall").Type);
			recipek.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			recipek.AddIngredient(Mod,"ItemJawFossil");;
			recipek.AddIngredient(Mod,"ItemExpCandyS");;
			recipek.Register();
			
			//Gen 8 Fossils
			Recipe recipel = Recipe.Create(Mod.Find<ModItem>("DracozoltBall").Type);
			recipel.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			recipel.AddIngredient(Mod,"ItemFossilizedDrake");;
			recipel.AddIngredient(Mod,"ItemFossilizedBird");;
			recipel.AddIngredient(Mod,"ItemExpCandyL");;
			recipel.Register();
			
			Recipe recipem = Recipe.Create(Mod.Find<ModItem>("DracovishBall").Type);
			recipem.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			recipem.AddIngredient(Mod,"ItemFossilizedDrake");;
			recipem.AddIngredient(Mod,"ItemFossilizedFish");;
			recipem.AddIngredient(Mod,"ItemExpCandyL");;
			recipem.Register();
			
			Recipe recipen = Recipe.Create(Mod.Find<ModItem>("ArctozoltBall").Type);
			recipen.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			recipen.AddIngredient(Mod,"ItemFossilizedDino");;
			recipen.AddIngredient(Mod,"ItemFossilizedBird");;
			recipen.AddIngredient(Mod,"ItemExpCandyL");;
			recipen.Register();
			
			Recipe recipeo = Recipe.Create(Mod.Find<ModItem>("ArctovishBall").Type);
			recipeo.AddTile(Mod.Find<ModTile>("FossilMachine").Type);
			recipeo.AddIngredient(Mod,"ItemFossilizedDino");;
			recipeo.AddIngredient(Mod,"ItemFossilizedFish");;
			recipeo.AddIngredient(Mod,"ItemExpCandyL");;
			recipeo.Register();
		}
	}
}