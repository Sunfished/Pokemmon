using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCarracosta : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Carracosta!");
			Description.SetDefault("+74 HP\n+21% Melee/Ranged Damage\n+13 Melee/Ranged Defense\n+16% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.2 Speed\nWater Type: Allows swimming and water breathing\nRock Type: Increases Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Carracosta")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCarracosta = true;
				modPlayer.buffWaterType = true;
				modPlayer.buffRockType = true;
			}
			if (!modPlayer.summonedCarracosta || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 13;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 74;
			player.meleeDamage *= 1.21f;
			player.rangedDamage *= 1.21f;
			player.magicDamage *= 1.16f;
			player.minionDamage *= 1.16f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}