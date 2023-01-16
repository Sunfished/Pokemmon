using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffGligar : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Gligar!");
			Description.SetDefault("+65 HP\n+15% Melee/Ranged Damage\n+10 Melee/Ranged Defense\n+7% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.4 Speed\nGround Type: Nullifies Knockback\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Gligar").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedGligar = true;
				modPlayer.buffGroundType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedGligar || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGroundType = false;
				modPlayer.buffFlyingType = false;
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
				player.statDefense += 10;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 65;
			player.GetDamage(DamageClass.Melee) *= 1.15f;
			player.GetDamage(DamageClass.Ranged) *= 1.15f;
			player.GetDamage(DamageClass.Magic) *= 1.07f;
			player.GetDamage(DamageClass.Summon) *= 1.07f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}