using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffAbomasnowMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Abomasnow!");
			Description.SetDefault("+90 HP\n+26% Melee/Ranged Damage\n+10 Melee/Ranged Defense\n+26% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.1 Speed\nIce Type: Unimplemented Effect\nGrass Type: Regens HP during daytime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("AbomasnowMega")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedAbomasnowMega = true;
				modPlayer.buffIceType = true;
				modPlayer.buffGrassType = true;
			}
			if (!modPlayer.summonedAbomasnowMega || modPlayer.pokemonAmount > 1) {
				modPlayer.buffIceType = false;
				modPlayer.buffGrassType = false;
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
				player.statDefense += 10;
			}
			else
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 90;
			player.meleeDamage *= 1.26f;
			player.rangedDamage *= 1.26f;
			player.magicDamage *= 1.26f;
			player.minionDamage *= 1.26f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}