using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffPumpkabooAverageSize : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Pumpkaboo!");
			Description.SetDefault("+49 HP\n+13% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+8% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.3 Speed\nGhost Type: Unimplemented Effect\nGrass Type: Regens HP during daytime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("PumpkabooAverageSize")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedPumpkabooAverageSize = true;
				modPlayer.buffGhostType = true;
				modPlayer.buffGrassType = true;
			}
			if (!modPlayer.summonedPumpkabooAverageSize || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGhostType = false;
				modPlayer.buffGrassType = false;
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
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 49;
			player.meleeDamage *= 1.13f;
			player.rangedDamage *= 1.13f;
			player.magicDamage *= 1.08f;
			player.minionDamage *= 1.08f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}