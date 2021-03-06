using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffShellosEastSea : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Shellos!");
			Description.SetDefault("+76 HP\n+9% Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+11% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.2 Speed\nWater Type: Allows swimming and water breathing");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("ShellosEastSea")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedShellosEastSea = true;
				modPlayer.buffWaterType = true;
			}
			if (!modPlayer.summonedShellosEastSea || modPlayer.pokemonAmount > 1) {
				modPlayer.buffWaterType = false;
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
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 76;
			player.meleeDamage *= 1.09f;
			player.rangedDamage *= 1.09f;
			player.magicDamage *= 1.11f;
			player.minionDamage *= 1.11f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}