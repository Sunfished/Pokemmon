using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffKomala : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Komala!");
			Description.SetDefault("+65 HP\n+23% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+15% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.3 Speed\nNormal Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Komala")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedKomala = true;
				modPlayer.buffNormalType = true;
			}
			if (!modPlayer.summonedKomala || modPlayer.pokemonAmount > 1) {
				modPlayer.buffNormalType = false;
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
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 65;
			player.meleeDamage *= 1.23f;
			player.rangedDamage *= 1.23f;
			player.magicDamage *= 1.15f;
			player.minionDamage *= 1.15f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}