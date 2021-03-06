using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffAggronMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Aggron!");
			Description.SetDefault("+70 HP\n+28% Melee/Ranged Damage\n+23 Melee/Ranged Defense\n+12% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.2 Speed\nSteel Type: Decreases incoming DMG by 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("AggronMega")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedAggronMega = true;
				modPlayer.buffSteelType = true;
			}
			if (!modPlayer.summonedAggronMega || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 23;
			}
			else
			{
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 70;
			player.meleeDamage *= 1.28f;
			player.rangedDamage *= 1.28f;
			player.magicDamage *= 1.12f;
			player.minionDamage *= 1.12f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}