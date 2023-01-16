using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items.Pokemon
{
	//imported from my tAPI mod because I'm lazy
	public class MilceryBall : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Milcery's Pokeball");
			//Tooltip.SetDefault("");
			
		}

		public override void SetDefaults() {
			Item.damage = 11;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 1;
			Item.width = 18;
			Item.height = 18;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = 43137;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item4;
			Item.shoot = Mod.Find<ModProjectile>("Milcery").Type;
			Item.shootSpeed = 10f;
			Item.buffType = Mod.Find<ModBuff>("BuffMilcery").Type; //The buff added to player after used the item
			Item.buffTime = 3600;               //The duration of the buff, here is 60 seconds
			Item.stack = 1;
			Item.maxStack = 999;
		}

		public override bool AltFunctionUse(Player player) {
			return true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			modPlayer.ResetEffects();
			modPlayer.pokemonAmount++;
			//modPlayer.summonedMilcery = true;
			return player.altFunctionUse != 2;
		}

		public override Nullable<bool> UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */ {
			if (player.altFunctionUse == 2) {
				player.MinionNPCTargetAim(true);
			}
			return base.UseItem(player);
		}
		
		public override void AddRecipes()
		{
			Recipe recipe0 = Recipe.Create(Mod.Find<ModItem>("AlcremieVanillaCreamBall").Type);
			recipe0.AddIngredient(this);
			recipe0.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe0.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe0.AddIngredient(Mod.Find<ModItem>("ItemSunStone").Type,1);
			recipe0.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe0.Register();

			Recipe recipe1 = Recipe.Create(Mod.Find<ModItem>("AlcremieRubyCreamBall").Type);
			recipe1.AddIngredient(this);
			recipe1.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe1.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe1.AddIngredient(Mod.Find<ModItem>("ItemSunStone").Type,1);
			recipe1.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe1.Register();

			Recipe recipe2 = Recipe.Create(Mod.Find<ModItem>("AlcremieMatchaCreamBall").Type);
			recipe2.AddIngredient(this);
			recipe2.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe2.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe2.AddIngredient(Mod.Find<ModItem>("ItemMoonStone").Type,1);
			recipe2.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe2.Register();

			Recipe recipe3 = Recipe.Create(Mod.Find<ModItem>("AlcremieMintCreamBall").Type);
			recipe3.AddIngredient(this);
			recipe3.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe3.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe3.AddIngredient(Mod.Find<ModItem>("ItemMoonStone").Type,1);
			recipe3.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe3.Register();

			Recipe recipe4 = Recipe.Create(Mod.Find<ModItem>("AlcremieLemonCreamBall").Type);
			recipe4.AddIngredient(this);
			recipe4.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe4.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe4.AddIngredient(Mod.Find<ModItem>("ItemMoonStone").Type,1);
			recipe4.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe4.Register();

			Recipe recipe5 = Recipe.Create(Mod.Find<ModItem>("AlcremieSaltedCreamBall").Type);
			recipe5.AddIngredient(this);
			recipe5.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe5.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe5.AddIngredient(Mod.Find<ModItem>("ItemMoonStone").Type,1);
			recipe5.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe5.Register();

			Recipe recipe6 = Recipe.Create(Mod.Find<ModItem>("AlcremieRubySwirlBall").Type);
			recipe6.AddIngredient(this);
			recipe6.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe6.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe6.AddIngredient(Mod.Find<ModItem>("ItemSunStone").Type,1);
			recipe6.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe6.Register();

			Recipe recipe7 = Recipe.Create(Mod.Find<ModItem>("AlcremieCaramelSwirlBall").Type);
			recipe7.AddIngredient(this);
			recipe7.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe7.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe7.AddIngredient(Mod.Find<ModItem>("ItemSunStone").Type,1);
			recipe7.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe7.Register();

			Recipe recipe8 = Recipe.Create(Mod.Find<ModItem>("AlcremieRainbowCreamBall").Type);
			recipe8.AddIngredient(this);
			recipe8.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe8.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,1);
			recipe8.AddIngredient(Mod.Find<ModItem>("ItemDuskStone").Type,1);
			recipe8.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe8.Register();


		}
	}
}