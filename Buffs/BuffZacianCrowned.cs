using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffZacianCrowned : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Zacian!");
			Description.SetDefault("+92 HP\n+30% Melee/Ranged Damage\n+11 Melee/Ranged Defense\n+16% Magic/Summon Damage\n+11 Magic/Summon Defense\n+0.7 Speed\nFairy Type: Regens HP during nighttime\nSteel Type: Decreases incoming DMG by 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("ZacianCrowned")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedZacianCrowned = true;
				modPlayer.buffFairyType = true;
				modPlayer.buffSteelType = true;
			}
			if (!modPlayer.summonedZacianCrowned || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFairyType = false;
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
				player.statDefense += 11;
			}
			else
			{
				player.statDefense += 11;
			}
			
			player.statLifeMax2 += 92;
			player.meleeDamage *= 1.3f;
			player.rangedDamage *= 1.3f;
			player.magicDamage *= 1.16f;
			player.minionDamage *= 1.16f;
			player.maxRunSpeed += 0.7f;
			
			//modPlayer.numSpawned++;
		}
	}
}