using Pokemmon.Items;
using Pokemmon.Items.PokeBoxes;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PokemmonGlobalNPC.NPCs
{
	public class PokemmonGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		
		public override void NPCLoot(NPC npc) {
			
			//Martian Saucer drops ultra box
			if (npc.type == NPCID.MartianSaucerCore && Main.rand.Next(10) == 0) {
				Item.NewItem(npc.getRect(), ModContent.ItemType<BeastBox>(), 1);
			}
		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot) {
			
			//Travelling Merchant
			if (type == NPCID.TravellingMerchant)
			{
				//Malasada and Wishing Star
				//Mutually exclusive
				if(Main.rand.Next(2) == 0)
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemMalasada>());
					nextSlot++;
				}
				else
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemWishingStar>());
					nextSlot++;
				}
				
				//Chipped Pot and Cracked Pot
				//Chance to sell Cracked Pot, rarer chance to sell Chipped Pot
				if(Main.rand.Next(3) == 0)
				{
					if (Main.rand.Next(3) == 0)
					{
						shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemChippedPot>());
						nextSlot++;
					}
					else
					{
						shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemCrackedPot>());
						nextSlot++;
					}
				}
				
				//SportsBox
				if(Main.rand.Next(15) == 0)
				{
					shop.item[nextSlot].SetDefaults(ModContent.ItemType<SportBox>());
					nextSlot++;
				}
			}
			
			//Clothier
			else if (type == NPCID.Clothier)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemToyRemoraid>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemToyShelmet>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemToyKarrablast>());
				nextSlot++;
			}
			
			//Demolitionist
			else if (type == NPCID.Demolitionist)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemPowerBracer>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemPowerAnklet>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemPowerBelt>());
				nextSlot++;
			}
			
			//Party Girl
			else if (type == NPCID.PartyGirl)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemHeartScale>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemSachet>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemWhippedDream>());
				nextSlot++;
			}
			
			//Dryad
			else if (type == NPCID.Dryad)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemGalarianLeek>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemSweetApple>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemTartApple>());
				nextSlot++;
			}
			
			//Witch Doctor
			else if (type == NPCID.WitchDoctor)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemShedShell>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemRazorFang>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemRazorClaw>());
				nextSlot++;
			}
			
			//Wizard
			else if (type == NPCID.Wizard)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemDragonScale>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemReaperCloth>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemMetronome>());
				nextSlot++;
			}
			
			//Steampunker
			else if (type == NPCID.Steampunker)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemMagmarizer>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemElectrizer>());
				nextSlot++;
			}
			
			//Arms Dealer
			else if (type == NPCID.ArmsDealer)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemMetalCoat>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemProtector>());
				nextSlot++;
			}
			
			//Cyborg
			else if (type == NPCID.Cyborg)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemDubiousDisc>());
				nextSlot++;
			}

			//Mechanic
			else if (type == NPCID.Mechanic)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemUpGrade>());
				nextSlot++;
			}
			
			//Painter
			else if (type == NPCID.Painter)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemOvalStone>());
				nextSlot++;
			}

			
			//Stylist
			else if (type == NPCID.Stylist)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemMPheromone>());
				nextSlot++;
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<ItemFPheromone>());
				nextSlot++;
			}
		}
	}
}