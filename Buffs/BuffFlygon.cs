using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffFlygon : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Flygon!");
			Description.SetDefault("+80 HP\n+20% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+16% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.5 Speed\nGround Type: Nullifies Knockback\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Flygon").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedFlygon = true;
				modPlayer.buffGroundType = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedFlygon || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGroundType = false;
				modPlayer.buffDragonType = false;
				player.DelBuff(buffIndex);
				buffIndex--;
				modPlayer.pokemonAmount = 0;
			}
		
			//Calc Buffs
			var isMelee = true;
			if(player.GetDamage(DamageClass.Magic).Flat > player.GetDamage(DamageClass.Melee).Flat || player.GetDamage(DamageClass.Magic).Flat > player.GetDamage(DamageClass.Ranged).Flat ||
			player.GetDamage(DamageClass.Summon).Flat > player.GetDamage(DamageClass.Melee).Flat || player.GetDamage(DamageClass.Summon).Flat > player.GetDamage(DamageClass.Ranged).Flat)
				isMelee = false;
			if (isMelee)
			{
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 80;
			player.GetDamage(DamageClass.Melee) *= 1.2f;
			player.GetDamage(DamageClass.Ranged) *= 1.2f;
			player.GetDamage(DamageClass.Magic) *= 1.16f;
			player.GetDamage(DamageClass.Summon) *= 1.16f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}