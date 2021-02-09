using Pokemmon.Items.Pokemon;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Terraria.ModLoader.IO;
using Terraria.Utilities;

namespace PokemmonGlobalItem.Items
{
	public class PokemmonGlobalItem : GlobalItem
	{
		// Prevent Prefixes on Pokeballs
		public override bool? PrefixChance(Item item, int pre, UnifiedRandom rand) {
			if (pre == -1) {
				if (item.summon && item.modItem?.mod == mod) {
					return false;
				}
			}
			return null;
		}
		
		// Fishing Crate Items
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
		
		// Items from Desert Fossils used in Extractinator
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
			
			//Meltan Candy - Iron Ore
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.Furnaces);
			recipe.AddIngredient(mod.ItemType("ItemExpCandyXL"));
			recipe.AddIngredient(ItemID.IronOre, 400);
			recipe.SetResult(mod.ItemType("ItemMeltanCandy"));
			recipe.AddRecipe();
			
			//Meltan Candy - Iron Bar
			ModRecipe recipeMeltan2 = new ModRecipe(mod);
			recipeMeltan2.AddTile(TileID.Furnaces);
			recipeMeltan2.AddIngredient(mod.ItemType("ItemExpCandyXL"));
			recipeMeltan2.AddIngredient(ItemID.IronBar, 133);
			recipeMeltan2.SetResult(mod.ItemType("ItemMeltanCandy"));
			recipeMeltan2.AddRecipe();
			
			//Meltan Candy - Lead Ore
			ModRecipe recipe22 = new ModRecipe(mod);
			recipe22.AddTile(TileID.Furnaces);
			recipe22.AddIngredient(mod.ItemType("ItemExpCandyXL"));
			recipe22.AddIngredient(ItemID.LeadOre, 400);
			recipe22.SetResult(mod.ItemType("ItemMeltanCandy"));
			recipe22.AddRecipe();
			
			//Meltan Candy - Lead Bar
			ModRecipe recipeMeltan22 = new ModRecipe(mod);
			recipeMeltan22.AddTile(TileID.Furnaces);
			recipeMeltan22.AddIngredient(mod.ItemType("ItemExpCandyXL"));
			recipeMeltan22.AddIngredient(ItemID.LeadBar, 133);
			recipeMeltan22.SetResult(mod.ItemType("ItemMeltanCandy"));
			recipeMeltan22.AddRecipe();
			
		}
	}
}