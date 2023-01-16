using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items.Pokemon
{
	//imported from my tAPI mod because I'm lazy
	public class SpewpaBall : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Spewpa's Pokeball");
			//Tooltip.SetDefault("");
			
		}

		public override void SetDefaults() {
			Item.damage = 6;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 1;
			Item.width = 18;
			Item.height = 18;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.noMelee = true;
			Item.knockBack = 0;
			Item.value = 105882;
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item4;
			Item.shoot = Mod.Find<ModProjectile>("Spewpa").Type;
			Item.shootSpeed = 10f;
			Item.buffType = Mod.Find<ModBuff>("BuffSpewpa").Type; //The buff added to player after used the item
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
			//modPlayer.summonedSpewpa = true;
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
			Recipe recipe0 = Recipe.Create(Mod.Find<ModItem>("VivillonMeadowBall").Type);
			recipe0.AddIngredient(this);
			recipe0.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe0.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe0.Register();

			Recipe recipe1 = Recipe.Create(Mod.Find<ModItem>("VivillonArchipelagoBall").Type);
			recipe1.AddIngredient(this);
			recipe1.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe1.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe1.Register();

			Recipe recipe2 = Recipe.Create(Mod.Find<ModItem>("VivillonContinentalBall").Type);
			recipe2.AddIngredient(this);
			recipe2.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe2.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe2.Register();

			Recipe recipe3 = Recipe.Create(Mod.Find<ModItem>("VivillonElegantBall").Type);
			recipe3.AddIngredient(this);
			recipe3.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe3.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe3.Register();

			Recipe recipe4 = Recipe.Create(Mod.Find<ModItem>("VivillonGardenBall").Type);
			recipe4.AddIngredient(this);
			recipe4.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe4.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe4.Register();

			Recipe recipe5 = Recipe.Create(Mod.Find<ModItem>("VivillonHighPlainsBall").Type);
			recipe5.AddIngredient(this);
			recipe5.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe5.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe5.Register();

			Recipe recipe6 = Recipe.Create(Mod.Find<ModItem>("VivillonIcySnowBall").Type);
			recipe6.AddIngredient(this);
			recipe6.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe6.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe6.Register();

			Recipe recipe7 = Recipe.Create(Mod.Find<ModItem>("VivillonJungleBall").Type);
			recipe7.AddIngredient(this);
			recipe7.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe7.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe7.Register();

			Recipe recipe8 = Recipe.Create(Mod.Find<ModItem>("VivillonMarineBall").Type);
			recipe8.AddIngredient(this);
			recipe8.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe8.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe8.Register();

			Recipe recipe9 = Recipe.Create(Mod.Find<ModItem>("VivillonModernBall").Type);
			recipe9.AddIngredient(this);
			recipe9.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe9.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe9.Register();

			Recipe recipe10 = Recipe.Create(Mod.Find<ModItem>("VivillonMonsoonBall").Type);
			recipe10.AddIngredient(this);
			recipe10.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe10.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe10.Register();

			Recipe recipe11 = Recipe.Create(Mod.Find<ModItem>("VivillonOceanBall").Type);
			recipe11.AddIngredient(this);
			recipe11.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe11.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe11.Register();

			Recipe recipe12 = Recipe.Create(Mod.Find<ModItem>("VivillonPolarBall").Type);
			recipe12.AddIngredient(this);
			recipe12.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe12.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe12.Register();

			Recipe recipe13 = Recipe.Create(Mod.Find<ModItem>("VivillonRiverBall").Type);
			recipe13.AddIngredient(this);
			recipe13.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe13.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe13.Register();

			Recipe recipe14 = Recipe.Create(Mod.Find<ModItem>("VivillonSandstormBall").Type);
			recipe14.AddIngredient(this);
			recipe14.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe14.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe14.Register();

			Recipe recipe15 = Recipe.Create(Mod.Find<ModItem>("VivillonSavannaBall").Type);
			recipe15.AddIngredient(this);
			recipe15.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe15.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe15.Register();

			Recipe recipe16 = Recipe.Create(Mod.Find<ModItem>("VivillonSunBall").Type);
			recipe16.AddIngredient(this);
			recipe16.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe16.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe16.Register();

			Recipe recipe17 = Recipe.Create(Mod.Find<ModItem>("VivillonTundraBall").Type);
			recipe17.AddIngredient(this);
			recipe17.AddIngredient(Mod.Find<ModItem>("ItemExpCandyS").Type,12);
			recipe17.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe17.Register();

			Recipe recipe99 = Recipe.Create(Mod.Find<ModItem>("ScatterbugBall").Type);
			recipe99.AddIngredient(this);
			recipe99.AddIngredient(Mod.Find<ModItem>("ItemEverstone").Type,1);
			recipe99.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe99.Register();


		}
	}
}