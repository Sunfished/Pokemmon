using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMienfoo : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Mienfoo!");
			Description.SetDefault("+45 HP\n+17% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+11% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.3 Speed\nFighting Type: Increases DMG when HP > 50%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Mienfoo")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMienfoo = true;
				modPlayer.buffFightingType = true;
			}
			if (!modPlayer.summonedMienfoo || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 45;
			player.meleeDamage *= 1.17f;
			player.rangedDamage *= 1.17f;
			player.magicDamage *= 1.11f;
			player.minionDamage *= 1.11f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}