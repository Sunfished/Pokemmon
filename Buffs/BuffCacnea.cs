using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCacnea : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Cacnea!");
			Description.SetDefault("+50 HP\n+17% Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+17% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.2 Speed\nGrass Type: Regens HP during daytime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Cacnea")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCacnea = true;
				modPlayer.buffGrassType = true;
			}
			if (!modPlayer.summonedCacnea || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 50;
			player.meleeDamage *= 1.17f;
			player.rangedDamage *= 1.17f;
			player.magicDamage *= 1.17f;
			player.minionDamage *= 1.17f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}