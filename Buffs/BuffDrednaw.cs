using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffDrednaw : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Drednaw!");
			Description.SetDefault("+90 HP\n+23% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+9% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.4 Speed\nWater Type: Allows swimming and water breathing\nRock Type: Increases Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Drednaw")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedDrednaw = true;
				modPlayer.buffWaterType = true;
				modPlayer.buffRockType = true;
			}
			if (!modPlayer.summonedDrednaw || modPlayer.pokemonAmount > 1) {
				modPlayer.buffWaterType = false;
				modPlayer.buffRockType = false;
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
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 90;
			player.meleeDamage *= 1.23f;
			player.rangedDamage *= 1.23f;
			player.magicDamage *= 1.09f;
			player.minionDamage *= 1.09f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}