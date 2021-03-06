using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffPluffle : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Pluffle!");
			Description.SetDefault("+74 HP\n+7% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+13% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.2 Speed\nFairy Type: Regens HP during nighttime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Pluffle")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedPluffle = true;
				modPlayer.buffFairyType = true;
			}
			if (!modPlayer.summonedPluffle || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFairyType = false;
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 74;
			player.meleeDamage *= 1.07f;
			player.rangedDamage *= 1.07f;
			player.magicDamage *= 1.13f;
			player.minionDamage *= 1.13f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}