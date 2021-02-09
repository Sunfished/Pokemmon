using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffScratchet : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Scratchet!");
			Description.SetDefault("+55 HP\n+17% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+4% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.2 Speed\nNormal Type: Unimplemented Effect\nFighting Type: Increases DMG when HP > 50%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Scratchet")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedScratchet = true;
				modPlayer.buffNormalType = true;
				modPlayer.buffFightingType = true;
			}
			if (!modPlayer.summonedScratchet || modPlayer.pokemonAmount > 1) {
				modPlayer.buffNormalType = false;
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 55;
			player.meleeDamage *= 1.17f;
			player.rangedDamage *= 1.17f;
			player.magicDamage *= 1.04f;
			player.minionDamage *= 1.04f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}