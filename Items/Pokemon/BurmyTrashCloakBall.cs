using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items.Pokemon
{
	//imported from my tAPI mod because I'm lazy
	public class BurmyTrashCloakBall : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Burmy's Pokeball");
			//Tooltip.SetDefault("");
			Tooltip.SetDefault("Trash Cloak Forme");
		}

		public override void SetDefaults() {
			Item.damage = 7;
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
			Item.shoot = Mod.Find<ModProjectile>("BurmyTrashCloak").Type;
			Item.shootSpeed = 10f;
			Item.buffType = Mod.Find<ModBuff>("BuffBurmyTrashCloak").Type; //The buff added to player after used the item
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
			//modPlayer.summonedBurmyTrashCloak = true;
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
			Recipe recipe0 = Recipe.Create(Mod.Find<ModItem>("WormadamTrashCloakBall").Type);
			recipe0.AddIngredient(this);
			recipe0.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,20);
			recipe0.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe0.Register();

			Recipe recipe1 = Recipe.Create(Mod.Find<ModItem>("MothimBall").Type);
			recipe1.AddIngredient(this);
			recipe1.AddIngredient(Mod.Find<ModItem>("ItemExpCandyM").Type,20);
			recipe1.AddIngredient(Mod.Find<ModItem>("ItemMPheromone").Type,1);
			recipe1.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe1.Register();


		}
	}
}