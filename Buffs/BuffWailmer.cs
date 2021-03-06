using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffWailmer : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Wailmer!");
			Description.SetDefault("+130 HP\n+14% Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+14% Magic/Summon Damage\n+3 Magic/Summon Defense\n+0.3 Speed\nWater Type: Allows swimming and water breathing");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Wailmer")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedWailmer = true;
				modPlayer.buffWaterType = true;
			}
			if (!modPlayer.summonedWailmer || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 130;
			player.meleeDamage *= 1.14f;
			player.rangedDamage *= 1.14f;
			player.magicDamage *= 1.14f;
			player.minionDamage *= 1.14f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}