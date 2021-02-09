using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffFeebas : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Feebas!");
			Description.SetDefault("+20 HP\n+3% Melee/Ranged Damage\n+2 Melee/Ranged Defense\n+2% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.4 Speed\nWater Type: Allows swimming and water breathing");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Feebas")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedFeebas = true;
				modPlayer.buffWaterType = true;
			}
			if (!modPlayer.summonedFeebas || modPlayer.pokemonAmount > 1) {
				modPlayer.buffWaterType = false;
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
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 20;
			player.meleeDamage *= 1.03f;
			player.rangedDamage *= 1.03f;
			player.magicDamage *= 1.02f;
			player.minionDamage *= 1.02f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}