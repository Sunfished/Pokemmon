using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Items.Pokemon
{
	//imported from my tAPI mod because I'm lazy
	public class MachampBall : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Machamp's Pokeball");
			//Tooltip.SetDefault("");
			
		}

		public override void SetDefaults() {
			Item.damage = 28;
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
			Item.shoot = Mod.Find<ModProjectile>("Machamp").Type;
			Item.shootSpeed = 10f;
			Item.buffType = Mod.Find<ModBuff>("BuffMachamp").Type; //The buff added to player after used the item
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
			//modPlayer.summonedMachamp = true;
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
			Recipe recipe99 = Recipe.Create(Mod.Find<ModItem>("MachokeBall").Type);
			recipe99.AddIngredient(this);
			recipe99.AddIngredient(Mod.Find<ModItem>("ItemEverstone").Type,1);
			recipe99.AddTile(Mod.Find<ModTile>("EvolutionMachine").Type);
			recipe99.Register();


		}
	}
}