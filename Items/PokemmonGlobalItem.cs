using Pokemmon.Items.Pokemon;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PokemmonGlobalItem.Items
{
	public class PokemmonGlobalItem : GlobalItem
	{
		public override void OpenVanillaBag(string context, Player player, int arg) {
			if (context == "crate")
			{
				bool passed = false;
				if (arg == ItemID.WoodenCrate && Main.rand.NextFloat() < 0.03333f)
					passed = true;
				
				if (arg == ItemID.IronCrate && Main.rand.NextFloat() < 0.05f)
					passed = true;
				
				if (arg == ItemID.GoldenCrate && Main.rand.NextFloat() < 0.1f)
					passed = true;
				
				if (passed)
				{
					string stone = "Leaf";
					int choice = Main.rand.Next(10);
					if (choice==0) stone = "Leaf";
					else if (choice==1) stone = "Fire";
					else if (choice==2) stone = "Water";
					else if (choice==3) stone = "Thunder";
					else if (choice==4) stone = "Sun";
					else if (choice==5) stone = "Moon";
					else if (choice==6) stone = "Shiny";
					else if (choice==7) stone = "Dusk";
					else if (choice==8) stone = "Dawn";
					else if (choice==9) stone = "Ice";
					
					stone = "Item" + stone + "Stone";
					player.QuickSpawnItem(mod.ItemType(stone));
				}
			}
		}
		
		public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
		{
			if(extractType == 3347)
			{
				// 1/30 chance
				if(Main.rand.NextFloat() < 0.03333f)
				{
					resultStack = 1;
					string mon = "ItemHelixFossil";
					
					int choice = Main.rand.Next(15);
					if(choice==0) mon = "ItemHelixFossil";
					else if(choice==1) mon = "ItemDomeFossil";
					else if(choice==2) mon = "ItemOldAmber";
					else if(choice==3) mon = "ItemClawFossil";
					else if(choice==4) mon = "ItemRootFossil";
					else if(choice==5) mon = "ItemArmorFossil";
					else if(choice==6) mon = "ItemSkullFossil";
					else if(choice==7) mon = "ItemPlumeFossil";
					else if(choice==8) mon = "ItemCoverFossil";
					else if(choice==9) mon = "ItemSailFossil";
					else if(choice==10) mon = "ItemJawFossil";
					else if(choice==11) mon = "ItemFossilizedBird";
					else if(choice==12) mon = "ItemFossilizedDrake";
					else if(choice==13) mon = "ItemFossilizedFish";
					else if(choice==14) mon = "ItemFossilizedDino";
					
					resultType = mod.ItemType(mon);
				}
			}
		}
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.Furnaces);
			recipe.AddIngredient(mod.ItemType("ItemExpCandyXL"));
			recipe.AddIngredient(ItemID.IronOre, 400);
			recipe.SetResult(mod.ItemType("ItemMeltanCandy"));
			recipe.AddRecipe();
		}
	}
}