using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffFlaaffy : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Flaaffy!");
			Description.SetDefault("+70 HP\n+11% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+16% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.2 Speed\nElectric Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Flaaffy")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedFlaaffy = true;
				modPlayer.buffElectricType = true;
			}
			if (!modPlayer.summonedFlaaffy || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 70;
			player.meleeDamage *= 1.11f;
			player.rangedDamage *= 1.11f;
			player.magicDamage *= 1.16f;
			player.minionDamage *= 1.16f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}