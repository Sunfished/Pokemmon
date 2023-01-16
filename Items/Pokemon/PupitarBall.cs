using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items.Pokemon
{
	//imported from my tAPI mod because I'm lazy
	public class PupitarBall : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Pupitar's Pokeball");
			//Tooltip.SetDefault("");
			
		}

		public override void SetDefaults() {
			Item.damage = 18;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 1;
			Item.width = 18;
			Item.height = 18;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = 164705;
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item4;
			Item.shoot = Mod.Find<ModProjectile>("Pupitar").Type;
			Item.shootSpeed = 10f;
			Item.buffType = Mod.Find<ModBuff>("BuffPupitar").Type; //The buff added to player after used the item
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
			//modPlayer.summonedPupitar = true;
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
			Recipe recipe0 = Recipe.Create(Mod.Find<ModItem>("TyranitarBall").Type);
			recipe0.AddIngredient(this);
			recipe0.AddIngredient(Mod.Find<ModItem>("ItemExpCandyXL").Type,55);
			recipe0.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe0.Register();

			Recipe recipe99 = Recipe.Create(Mod.Find<ModItem>("LarvitarBall").Type);
			recipe99.AddIngredient(this);
			recipe99.AddIngredient(Mod.Find<ModItem>("ItemEverstone").Type,1);
			recipe99.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe99.Register();


		}
	}
}