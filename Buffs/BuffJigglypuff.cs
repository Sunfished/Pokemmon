using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffJigglypuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Jigglypuff!");
			Description.SetDefault("+115 HP\n+9% Melee/Ranged Damage\n+2 Melee/Ranged Defense\n+9% Magic/Summon Damage\n+2 Magic/Summon Defense\n+0.1 Speed\nNormal Type: Unimplemented Effect\nFairy Type: Regens HP during nighttime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Jigglypuff")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedJigglypuff = true;
				modPlayer.buffNormalType = true;
				modPlayer.buffFairyType = true;
			}
			if (!modPlayer.summonedJigglypuff || modPlayer.pokemonAmount > 1) {
				modPlayer.buffNormalType = false;
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
				player.statDefense += 2;
			}
			else
			{
				player.statDefense += 2;
			}
			
			player.statLifeMax2 += 115;
			player.meleeDamage *= 1.09f;
			player.rangedDamage *= 1.09f;
			player.magicDamage *= 1.09f;
			player.minionDamage *= 1.09f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}