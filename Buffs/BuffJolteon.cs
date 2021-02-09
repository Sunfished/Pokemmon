using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffJolteon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Jolteon!");
			Description.SetDefault("+65 HP\n+13% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+22% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.7 Speed\nElectric Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Jolteon")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedJolteon = true;
				modPlayer.buffElectricType = true;
			}
			if (!modPlayer.summonedJolteon || modPlayer.pokemonAmount > 1) {
				modPlayer.buffElectricType = false;
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
			player.meleeDamage *= 1.13f;
			player.rangedDamage *= 1.13f;
			player.magicDamage *= 1.22f;
			player.minionDamage *= 1.22f;
			player.maxRunSpeed += 0.7f;
			
			//modPlayer.numSpawned++;
		}
	}
}