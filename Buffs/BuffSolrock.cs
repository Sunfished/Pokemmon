using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSolrock : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Solrock!");
			Description.SetDefault("+90 HP\n+19% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+11% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.3 Speed\nRock Type: Increases Knockback\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Solrock")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSolrock = true;
				modPlayer.buffRockType = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedSolrock || modPlayer.pokemonAmount > 1) {
				modPlayer.buffRockType = false;
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
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 90;
			player.meleeDamage *= 1.19f;
			player.rangedDamage *= 1.19f;
			player.magicDamage *= 1.11f;
			player.minionDamage *= 1.11f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}