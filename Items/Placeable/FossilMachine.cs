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
			item.width = 40;
			item.height = 41;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150000;
			item.createTile = mod.TileType("FossilMachine");
		}

		public override void AddRecipes() {
			
			//Craft Itself
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.Anvils);
			recipe.AddIngredient(ItemID.IronBar, 20);
			recipe.SetResult(this);
			recipe.AddRecipe();
			
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddTile(TileID.Anvils);
			recipe2.AddIngredient(ItemID.LeadBar, 20);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
			
			//Gen 1 Fossils
			ModRecipe recipeA = new ModRecipe(mod);
			recipeA.AddTile(mod.TileType("FossilMachine"));
			recipeA.AddIngredient(mod.GetItem("ItemHelixFossil"));
			recipeA.AddIngredient(mod.GetItem("ItemExpCandyS"));
			recipeA.SetResult(mod.GetItem("OmanyteBall"));
			recipeA.AddRecipe();
			
			ModRecipe recipeB = new ModRecipe(mod);
			recipeB.AddTile(mod.TileType("FossilMachine"));
			recipeB.AddIngredient(mod.GetItem("ItemDomeFossil"));
			recipeB.AddIngredient(mod.GetItem("ItemExpCandyS"));
			recipeB.SetResult(mod.GetItem("KabutoBall"));
			recipeB.AddRecipe();
			
			ModRecipe recipec = new ModRecipe(mod);
			recipec.AddTile(mod.TileType("FossilMachine"));
			recipec.AddIngredient(mod.GetItem("ItemOldAmber"));
			recipec.AddIngredient(mod.GetItem("ItemExpCandyL"));
			recipec.SetResult(mod.GetItem("AerodactylBall"));
			recipec.AddRecipe();
			
			//Gen 3 Fossils
			ModRecipe reciped = new ModRecipe(mod);
			reciped.AddTile(mod.TileType("FossilMachine"));
			reciped.AddIngredient(mod.GetItem("ItemClawFossil"));
			reciped.AddIngredient(mod.GetItem("ItemExpCandyS"));
			reciped.SetResult(mod.GetItem("AnorithBall"));
			reciped.AddRecipe();
			
			ModRecipe recipee = new ModRecipe(mod);
			recipee.AddTile(mod.TileType("FossilMachine"));
			recipee.AddIngredient(mod.GetItem("ItemRootFossil"));
			recipee.AddIngredient(mod.GetItem("ItemExpCandyS"));
			recipee.SetResult(mod.GetItem("LileepBall"));
			recipee.AddRecipe();
			
			//Gen 4 Fossils
			ModRecipe recipef = new ModRecipe(mod);
			recipef.AddTile(mod.TileType("FossilMachine"));
			recipef.AddIngredient(mod.GetItem("ItemArmorFossil"));
			recipef.AddIngredient(mod.GetItem("ItemExpCandyS"));
			recipef.SetResult(mod.GetItem("ShieldonBall"));
			recipef.AddRecipe();
			
			ModRecipe recipeg = new ModRecipe(mod);
			recipeg.AddTile(mod.TileType("FossilMachine"));
			recipeg.AddIngredient(mod.GetItem("ItemSkullFossil"));
			recipeg.AddIngredient(mod.GetItem("ItemExpCandyS"));
			recipeg.SetResult(mod.GetItem("CranidosBall"));
			recipeg.AddRecipe();
			
			//Gen 5 Fossils
			ModRecipe recipeh = new ModRecipe(mod);
			recipeh.AddTile(mod.TileType("FossilMachine"));
			recipeh.AddIngredient(mod.GetItem("ItemPlumeFossil"));
			recipeh.AddIngredient(mod.GetItem("ItemExpCandyS"));
			recipeh.SetResult(mod.GetItem("ArchenBall"));
			recipeh.AddRecipe();
			
			ModRecipe recipei = new ModRecipe(mod);
			recipei.AddTile(mod.TileType("FossilMachine"));
			recipei.AddIngredient(mod.GetItem("ItemCoverFossil"));
			recipei.AddIngredient(mod.GetItem("ItemExpCandyS"));
			recipei.SetResult(mod.GetItem("TirtougaBall"));
			recipei.AddRecipe();
			
			//Gen 6 Fossils
			ModRecipe recipej = new ModRecipe(mod);
			recipej.AddTile(mod.TileType("FossilMachine"));
			recipej.AddIngredient(mod.GetItem("ItemSailFossil"));
			recipej.AddIngredient(mod.GetItem("ItemExpCandyS"));
			recipej.SetResult(mod.GetItem("AmauraBall"));
			recipej.AddRecipe();
			
			ModRecipe recipek = new ModRecipe(mod);
			recipek.AddTile(mod.TileType("FossilMachine"));
			recipek.AddIngredient(mod.GetItem("ItemJawFossil"));
			recipek.AddIngredient(mod.GetItem("ItemExpCandyS"));
			recipek.SetResult(mod.GetItem("TyruntBall"));
			recipek.AddRecipe();
			
			//Gen 8 Fossils
			ModRecipe recipel = new ModRecipe(mod);
			recipel.AddTile(mod.TileType("FossilMachine"));
			recipel.AddIngredient(mod.GetItem("ItemFossilizedDrake"));
			recipel.AddIngredient(mod.GetItem("ItemFossilizedBird"));
			recipel.AddIngredient(mod.GetItem("ItemExpCandyL"));
			recipel.SetResult(mod.GetItem("DracozoltBall"));
			recipel.AddRecipe();
			
			ModRecipe recipem = new ModRecipe(mod);
			recipem.AddTile(mod.TileType("FossilMachine"));
			recipem.AddIngredient(mod.GetItem("ItemFossilizedDrake"));
			recipem.AddIngredient(mod.GetItem("ItemFossilizedFish"));
			recipem.AddIngredient(mod.GetItem("ItemExpCandyL"));
			recipem.SetResult(mod.GetItem("DracovishBall"));
			recipem.AddRecipe();
			
			ModRecipe recipen = new ModRecipe(mod);
			recipen.AddTile(mod.TileType("FossilMachine"));
			recipen.AddIngredient(mod.GetItem("ItemFossilizedDino"));
			recipen.AddIngredient(mod.GetItem("ItemFossilizedBird"));
			recipen.AddIngredient(mod.GetItem("ItemExpCandyL"));
			recipen.SetResult(mod.GetItem("ArctozoltBall"));
			recipen.AddRecipe();
			
			ModRecipe recipeo = new ModRecipe(mod);
			recipeo.AddTile(mod.TileType("FossilMachine"));
			recipeo.AddIngredient(mod.GetItem("ItemFossilizedDino"));
			recipeo.AddIngredient(mod.GetItem("ItemFossilizedFish"));
			recipeo.AddIngredient(mod.GetItem("ItemExpCandyL"));
			recipeo.SetResult(mod.GetItem("ArctovishBall"));
			recipeo.AddRecipe();
		}
	}
}