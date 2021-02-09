using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSirfetchd : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Sirfetch'd!");
			Description.SetDefault("+62 HP\n+27% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+13% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.3 Speed\nFighting Type: Increases DMG when HP > 50%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Sirfetchd")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSirfetchd = true;
				modPlayer.buffFightingType = true;
			}
			if (!modPlayer.summonedSirfetchd || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 62;
			player.meleeDamage *= 1.27f;
			player.rangedDamage *= 1.27f;
			player.magicDamage *= 1.13f;
			player.minionDamage *= 1.13f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}