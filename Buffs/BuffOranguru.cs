using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffOranguru : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Oranguru!");
			Description.SetDefault("+90 HP\n+12% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+18% Magic/Summon Damage\n+11 Magic/Summon Defense\n+0.3 Speed\nNormal Type: Unimplemented Effect\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Oranguru")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedOranguru = true;
				modPlayer.buffNormalType = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedOranguru || modPlayer.pokemonAmount > 1) {
				modPlayer.buffNormalType = false;
				modPlayer.buffPsychicType = false;
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
				player.statDefense += 11;
			}
			
			player.statLifeMax2 += 90;
			player.meleeDamage *= 1.12f;
			player.rangedDamage *= 1.12f;
			player.magicDamage *= 1.18f;
			player.minionDamage *= 1.18f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}