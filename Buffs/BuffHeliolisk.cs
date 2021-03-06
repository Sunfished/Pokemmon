using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffHeliolisk : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Heliolisk!");
			Description.SetDefault("+62 HP\n+11% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+21% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.5 Speed\nElectric Type: Unimplemented Effect\nNormal Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Heliolisk")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedHeliolisk = true;
				modPlayer.buffElectricType = true;
				modPlayer.buffNormalType = true;
			}
			if (!modPlayer.summonedHeliolisk || modPlayer.pokemonAmount > 1) {
				modPlayer.buffElectricType = false;
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 62;
			player.meleeDamage *= 1.11f;
			player.rangedDamage *= 1.11f;
			player.magicDamage *= 1.21f;
			player.minionDamage *= 1.21f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}