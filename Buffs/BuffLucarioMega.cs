using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffLucarioMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Lucario!");
			Description.SetDefault("+70 HP\n+29% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+28% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.6 Speed\nFighting Type: Increases DMG when HP > 50%\nSteel Type: Decreases incoming DMG by 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("LucarioMega")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedLucarioMega = true;
				modPlayer.buffFightingType = true;
				modPlayer.buffSteelType = true;
			}
			if (!modPlayer.summonedLucarioMega || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFightingType = false;
				modPlayer.buffSteelType = false;
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 70;
			player.meleeDamage *= 1.29f;
			player.rangedDamage *= 1.29f;
			player.magicDamage *= 1.28f;
			player.minionDamage *= 1.28f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}