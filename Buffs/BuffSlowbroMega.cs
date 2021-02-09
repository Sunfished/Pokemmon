using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSlowbroMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Slowbro!");
			Description.SetDefault("+95 HP\n+15% Melee/Ranged Damage\n+18 Melee/Ranged Defense\n+26% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.1 Speed\nWater Type: Allows swimming and water breathing\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("SlowbroMega")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSlowbroMega = true;
				modPlayer.buffWaterType = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedSlowbroMega || modPlayer.pokemonAmount > 1) {
				modPlayer.buffWaterType = false;
				modPlayer.buffPsychicType = false;
				player.DelBuff(buffIndex);
				buffIndex--;
				modPlayer.pokemonAmount = 0;
			}
		
			//Calc Buffs
			var isMelee = true;
			if(player.magicDamage > player.meleeDamage || player.magicDamage > player.rangedDamage ||
			player.minionDamage > player.meleeDamage || player.minionDamage > player.rangedDamage)
				isMelee = false;
			if (isMelee)
			{
				player.statDefense += 18;
			}
			else
			{
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 95;
			player.meleeDamage *= 1.15f;
			player.rangedDamage *= 1.15f;
			player.magicDamage *= 1.26f;
			player.minionDamage *= 1.26f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}