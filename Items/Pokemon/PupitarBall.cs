using Microsoft.Xna.Framework;
using Terraria;
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
			item.damage = 19;
			item.summon = true;
			item.mana = 1;
			item.width = 18;
			item.height = 18;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 4;
			item.noMelee = true;
			item.knockBack = 2;
			item.value = 200000;
			item.rare = 8;
			item.UseSound = SoundID.Item4;
			item.shoot = mod.ProjectileType("Pupitar");
			item.shootSpeed = 10f;
			item.buffType = mod.BuffType("BuffPupitar"); //The buff added to player after used the item
			item.buffTime = 3600;               //The duration of the buff, here is 60 seconds
			item.stack = 1;
			item.maxStack = 999;
		}

		public override bool AltFunctionUse(Player player) {
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			modPlayer.ResetEffects();
			return player.altFunctionUse != 2;
		}

		public override bool UseItem(Player player) {
			if (player.altFunctionUse == 2) {
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe0 = new ModRecipe(mod);
			recipe0.AddIngredient(this);
			recipe0.AddIngredient(mod.GetItem("ItemExpCandyXL"),55);
			recipe0.SetResult(mod.ItemType("TyranitarBall"));
			recipe0.AddTile(mod.TileType("EvolutionMachine"));
			recipe0.AddRecipe();

			ModRecipe recipe99 = new ModRecipe(mod);
			recipe99.AddIngredient(this);
			recipe99.AddIngredient(mod.GetItem("ItemEverstone"),1);
			recipe99.SetResult(mod.ItemType("LarvitarBall"));
			recipe99.AddTile(mod.TileType("EvolutionMachine"));
			recipe99.AddRecipe();


		}
	}
}