using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffConkeldurr : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Conkeldurr!");
			Description.SetDefault("+105 HP\n+28% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+11% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.2 Speed\nFighting Type: Increases DMG when HP > 50%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Conkeldurr")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedConkeldurr = true;
				modPlayer.buffFightingType = true;
			}
			if (!modPlayer.summonedConkeldurr || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFightingType = false;
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
			
			player.statLifeMax2 += 105;
			player.meleeDamage *= 1.28f;
			player.rangedDamage *= 1.28f;
			player.magicDamage *= 1.11f;
			player.minionDamage *= 1.11f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}