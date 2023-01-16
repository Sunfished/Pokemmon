using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSwirlpool : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Swirlpool!");
			Description.SetDefault("+61 HP\n+9% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+10% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.1 Speed\nWater Type: Allows swimming and water breathing");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Swirlpool").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSwirlpool = true;
				modPlayer.buffWaterType = true;
			}
			if (!modPlayer.summonedSwirlpool || modPlayer.pokemonAmount > 1) {
				modPlayer.buffWaterType = false;
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
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 61;
			player.GetDamage(DamageClass.Melee) *= 1.09f;
			player.GetDamage(DamageClass.Ranged) *= 1.09f;
			player.GetDamage(DamageClass.Magic) *= 1.1f;
			player.GetDamage(DamageClass.Summon) *= 1.1f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}