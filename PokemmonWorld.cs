using Pokemmon.Items;
using Pokemmon.NPCs;
using Pokemmon.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;

namespace Pokemmon
{
	public class PokemmonWorld : ModWorld
	{
		// We use this hook to add 3 steps to world generation at various points. 
		/*public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) {
			// Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

			// The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
			// First, we find out which step "Shinies" is.
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
			if (ShiniesIndex != -1) {
				// Next, we insert our step directly after the original "Shinies" step. 
				// PokemmonOres is a method seen below.
				tasks.Insert(ShiniesIndex + 1, new PassLegacy("Example Mod Ores", PokemmonOres));
			}

			// This second step that we add will go after "Traps" and follows the same pattern.
			int TrapsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Traps"));
			if (TrapsIndex != -1) {
				tasks.Insert(TrapsIndex + 1, new PassLegacy("Example Mod Traps", PokemmonTraps));
			}

			int LivingTreesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Living Trees"));
			if (LivingTreesIndex != -1) {
				tasks.Insert(LivingTreesIndex + 1, new PassLegacy("Post Terrain", delegate (GenerationProgress progress) {
					// We can inline the world generation code like this, but if exceptions happen within this code 
					// the error messages are difficult to read, so making methods is better. This is called an anonymous method.
					progress.Message = "What is it Lassie, did Timmy fall down a well?";
					MakeWells();
				}));
			}
		}//*/

		/*private void PokemmonOres(GenerationProgress progress) {
			// progress.Message is the message shown to the user while the following code is running. Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes. 
			progress.Message = "Example Mod Ores";

			// Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
			// "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
			for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++) {
				// The inside of this for loop corresponds to one single splotch of our Ore.
				// First, we randomly choose any coordinate in the world by choosing a random x and y value.
				int x = WorldGen.genRand.Next(0, Main.maxTilesX);
				int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.

				// Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place. Feel free to experiment with strength and step to see the shape they generate.
				WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<ExampleOre>());

				// Alternately, we could check the tile already present in the coordinate we are interested. Wrapping WorldGen.TileRunner in the following condition would make the ore only generate in Snow.
				// Tile tile = Framing.GetTileSafely(x, y);
				// if (tile.active() && tile.type == TileID.SnowBlock)
				// {
				// 	WorldGen.TileRunner(.....);
				// }
			}
		}//*/
		
		// We can use PostWorldGen for world generation tasks that don't need to happen between vanilla world generation steps.
		public override void PostWorldGen() {
			
			//Items that are very commonly needed to evolve
			int[] commonItems = { ModContent.ItemType<ItemSootheBell>(), ModContent.ItemType<ItemLinkCable>(), ModContent.ItemType<ItemTM>() };
			int[] waterItems = {ModContent.ItemType<ItemPrismScale>(), ModContent.ItemType<ItemDeepSeaScale>(), ModContent.ItemType<ItemDeepSeaTooth>(),
								ModContent.ItemType<ItemKingsRock>()};

			// Normal Chests
			int commonItemsChoice = 0;
			int waterItemsChoice = 0;
			
			int addedCommonItems = 0;
			
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++) {
				Chest chest = Main.chest[chestIndex];
				
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
				//https://terraria.gamepedia.com/Tile_IDs
				
				if(chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers)
				{
					
					//Guranteed spawn of 1 Common, afterwards 1/5th chance
					if (Main.tile[chest.x, chest.y].frameX == 0 * 36) {
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++) {
							if (chest.item[inventoryIndex].type == ItemID.None) {
								if(addedCommonItems <= commonItems.Length || Main.rand.Next(5) == 0)
								{
									var myItem = commonItems[commonItemsChoice];
									chest.item[inventoryIndex].SetDefaults(myItem);
									mod.Logger.Info("Added Pokemmon Item to Common Chest");
									commonItemsChoice = (commonItemsChoice + 1) % commonItems.Length;
									addedCommonItems++;
								}
								break;
							}
						}
					}
					
					//Every Water chest contains at least one Water Item 
					//chest id: 17
					if (Main.tile[chest.x, chest.y].frameX == 17 * 36) {
						for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++) {
							if (chest.item[inventoryIndex].type == ItemID.None) {
								chest.item[inventoryIndex].SetDefaults(waterItems[waterItemsChoice]);
								waterItemsChoice = (waterItemsChoice + 1) % waterItems.Length;
								mod.Logger.Info("Added Pokemmon Item to Water Chest");
								break;
							}
						}
					}
				}
			}
		}
	}
}