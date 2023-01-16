using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Pokemmon.NPCs
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class Professor : ModNPC
	{
		//public override string Texture => "Pokemmon/NPCs/Professor.png";

		//public override string[] AltTextures => new[] { "Pokemmon/NPCs/Professor_Alt_1" };

		public override bool IsLoadingEnabled(Mod mod) {
			return mod.ContentAutoloadingEnabled;
		}

		public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			DisplayName.SetDefault("Professor");
			Main.npcFrameCount[NPC.type] = 25;
			NPCID.Sets.ExtraFramesCount[NPC.type] = 9;
			NPCID.Sets.AttackFrameCount[NPC.type] = 4;
			NPCID.Sets.DangerDetectRange[NPC.type] = 700;
			NPCID.Sets.AttackType[NPC.type] = 0;
			NPCID.Sets.AttackTime[NPC.type] = 90;
			NPCID.Sets.AttackAverageChance[NPC.type] = 30;
			NPCID.Sets.HatOffsetY[NPC.type] = 4;
		}

		public override void SetDefaults() {
			NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 10;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
			AnimationType = NPCID.Guide;
		}

		/*public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++) {
				Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("Sparkle"));
			}
		}//*/

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			if (NPC.downedSlimeKing)  //spawn after King Slime
            {
                return true;
            }
            return false;
		}

		public override List<string> SetNPCNameList()/* tModPorter Suggestion: Return a list of names */ {
			switch (WorldGen.genRand.Next(25)) {
				case 0:
					return "Birch".Split(',').ToList();
				case 1:
					return "Hawthorn".Split(',').ToList();
				case 2:
					return "Ash".Split(',').ToList();
				case 3:
					return "Hemlock".Split(',').ToList();
				case 4:
					return "Hickory".Split(',').ToList();
				case 5:
					return "Aspen".Split(',').ToList();
				case 6:
					return "Elm".Split(',').ToList();
				case 7:
					return "Larch".Split(',').ToList();
				case 8:
					return "Fir".Split(',').ToList();
				case 9:
					return "Pine".Split(',').ToList();
				case 10:
					return "Maple".Split(',').ToList();
				case 11:
					return "Spruce".Split(',').ToList();
				case 12:
					return "Cedar".Split(',').ToList();
				case 13:
					return "Sycamore".Split(',').ToList();
				case 14:
					return "Walnut".Split(',').ToList();
				case 15:
					return "Willow".Split(',').ToList();
				case 16:
					return "Rowan".Split(',').ToList();
				case 17:
					return "Juniper".Split(',').ToList();
				case 18:
					return "Kukui".Split(',').ToList();
				case 19:
					return "Catalpa".Split(',').ToList();
				case 20:
					return "Cypress".Split(',').ToList();
				case 21:
					return "Yew".Split(',').ToList();
				case 22:
					return "Poplar".Split(',').ToList();
				case 23:
					return "Hazel".Split(',').ToList();
				default:
					return "Oak".Split(',').ToList();
			}
		}

		public override void FindFrame(int frameHeight) {
		}

		public override string GetChat() {
			/*int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4)) {
				return "Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?";
			} //*/
			switch (Main.rand.Next(4)) {
				case 0:
					return "Technology is amazing!";
				case 1:
					return "What a strange specimen...";
				case 2:
					if (NPC.downedBoss3)
						return "With the right items, you can evolve your Pokemon!";
					else
						return "I've been working on a machine to evolve Pokemon, but it's going to take a while...";
				default:
					return "Don't stray too far into the tall grass!";
			}
		}

		/* 
		// Consider using this alternate approach to choosing a random thing. Very useful for a variety of use cases.
		// The WeightedRandom class needs "using Terraria.Utilities;" to use
		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();

			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4))
			{
				chat.Add("Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?");
			}
			chat.Add("Sometimes I feel like I'm different from everyone else here.");
			chat.Add("What's your favorite color? My favorite colors are white and black.");
			chat.Add("What? I don't have any arms or legs? Oh, don't be ridiculous!");
			chat.Add("This message has a weight of 5, meaning it appears 5 times more often.", 5.0);
			chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; // chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}
		*/

		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
			/*button2 = "Awesomeify";
			if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
				button = "Upgrade " + Lang.GetItemNameValue(ItemID.HiveBackpack);//*/
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				// We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.
				/*if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
				{
					Main.PlaySound(SoundID.Item37); // Reforge/Anvil sound
					Main.npcChatText = $"I upgraded your {Lang.GetItemNameValue(ItemID.HiveBackpack)} to a {Lang.GetItemNameValue(mod.ItemType<Items.Accessories.WaspNest>())}";
					int hiveBackpackItemIndex = Main.LocalPlayer.FindItem(ItemID.HiveBackpack);
					Main.LocalPlayer.inventory[hiveBackpackItemIndex].TurnToAir();
					Main.Localplayer.QuickSpawnItem(player.GetSource_OpenItem(mod.ItemType<Items.Accessories.WaspNest>()), mod.ItemType<Items.Accessories.WaspNest>());
					return;
				}//*/
				shop = true;
			}
			/*else {
				// If the 2nd button is pressed, open the inventory...
				Main.playerInventory = true;
				// remove the chat window...
				Main.npcChatText = "";
				// and start an instance of our UIState.
				Pokemmon.Instance.ExamplePersonUserInterface.SetState(new UI.ExamplePersonUI());
				// Note that even though we remove the chat window, Main.LocalPlayer.talkNPC will still be set correctly and we are still technically chatting with the npc.
			}//*/
		}

		public override void SetupShop(Chest shop, ref int nextSlot) {
			
			//Grass Starters
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("BulbasaurBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("ChikoritaBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("TreeckoBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("TurtwigBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("SnivyBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("ChespinBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("RowletBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("GrookeyBall").Type);
			nextSlot++;

			//Fire Starters
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("CharmanderBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("CyndaquilBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("TorchicBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("ChimcharBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("TepigBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("FennekinBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("LittenBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("ScorbunnyBall").Type);
			nextSlot++;
			
			//Water Starters
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("SquirtleBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("TotodileBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("MudkipBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("PiplupBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("OshawottBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("FroakieBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("PopplioBall").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("SobbleBall").Type);
			nextSlot++;
			
			//PokeBoxes
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("PokeBox").Type);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("NestBox").Type);
			nextSlot++;
			
			//EverStone
			shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("ItemEverstone").Type);
			nextSlot++;
			
			//Evolution Machine After Brain/Worm
			if(NPC.downedBoss2)
			{
				shop.item[nextSlot].SetDefaults(Mod.Find<ModItem>("EvolutionMachine").Type);
				nextSlot++;
			}

			/*if (Main.LocalPlayer.HasBuff(BuffID.Lifeforce)) {
				shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleHealingPotion"));
				nextSlot++;
			}
			if (Main.LocalPlayer.GetModPlayer<ExamplePlayer>().ZoneExample && !ExampleMod.exampleServerConfig.DisableExampleWings) {
				shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleWings"));
				nextSlot++;
			}
			if (Main.moonPhase < 2) {
				shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleSword"));
				nextSlot++;
			}
			else if (Main.moonPhase < 4) {
				shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleGun"));
				nextSlot++;
				shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleBullet"));
				nextSlot++;
			}
			else if (Main.moonPhase < 6) {
				shop.item[nextSlot].SetDefaults(mod.ItemType("ExampleStaff"));
				nextSlot++;
			}
			else {
			}
			// Here is an example of how your npc can sell items from other mods.
			var modSummonersAssociation = ModLoader.GetMod("SummonersAssociation");
			if (modSummonersAssociation != null) {
				shop.item[nextSlot].SetDefaults(modSummonersAssociation.ItemType("BloodTalisman"));
				nextSlot++;
			}

			if (!Main.LocalPlayer.GetModPlayer<ExamplePlayer>().examplePersonGiftReceived && ExampleMod.exampleServerConfig.ExamplePersonFreeGiftList != null)
			{
				foreach (var item in ExampleMod.exampleServerConfig.ExamplePersonFreeGiftList)
				{
					if (item.IsUnloaded)
						continue;
					shop.item[nextSlot].SetDefaults(item.GetID());
					shop.item[nextSlot].shopCustomPrice = 0;
					shop.item[nextSlot].GetGlobalItem<ExampleInstancedGlobalItem>().examplePersonFreeGift = true;
					nextSlot++;
					// TODO: Have tModLoader handle index issues.
				}	
			}//*/
		}

		/*public override void NPCLoot() {
			Item.NewItem(npc.getRect(), mod.ItemType<Items.Armor.ExampleCostume>());
		}//*/

		// Make this Town NPC teleport to the King and/or Queen statue when triggered.
		/*public override bool CanGoToStatue(bool toKingStatue) {
			return true;
		}//*/

		// Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.
		/*public override void OnGoToStatue(bool toKingStatue) {
			if (Main.netMode == NetmodeID.Server) {
				ModPacket packet = mod.GetPacket();
				packet.Write((byte)ExampleModMessageType.ExampleTeleportToStatue);
				packet.Write((byte)npc.whoAmI);
				packet.Send();
			}
			else {
				StatueTeleport();
			}
		}//*/

		// Create a square of pixels around the NPC on teleport.
		public void StatueTeleport() {
			for (int i = 0; i < 30; i++) {
				Vector2 position = Main.rand.NextVector2Square(-20, 21);
				if (Math.Abs(position.X) > Math.Abs(position.Y)) {
					position.X = Math.Sign(position.X) * 20;
				}
				else {
					position.Y = Math.Sign(position.Y) * 20;
				}
				//Dust.NewDustPerfect(position, mod.DustType<Dusts.Pixel>(), Vector2.Zero).noGravity = true;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = Mod.Find<ModProjectile>("SparklingBall").Type;
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}