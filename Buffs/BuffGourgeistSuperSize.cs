using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffGourgeistSuperSize : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Gourgeist!");
			Description.SetDefault("+85 HP\n+20% Melee/Ranged Damage\n+12 Melee/Ranged Defense\n+11% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.3 Speed\nGhost Type: Unimplemented Effect\nGrass Type: Regens HP during daytime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("GourgeistSuperSize")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedGourgeistSuperSize = true;
				modPlayer.buffGhostType = true;
				modPlayer.buffGrassType = true;
			}
			if (!modPlayer.summonedGourgeistSuperSize || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 12;
			}
			else
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 85;
			player.meleeDamage *= 1.2f;
			player.rangedDamage *= 1.2f;
			player.magicDamage *= 1.11f;
			player.minionDamage *= 1.11f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}