using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffHeatmor : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Heatmor!");
			Description.SetDefault("+85 HP\n+19% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+21% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.3 Speed\nFire Type: Lights up area");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Heatmor")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedHeatmor = true;
				modPlayer.buffFireType = true;
			}
			if (!modPlayer.summonedHeatmor || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFireType = false;
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
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 85;
			player.meleeDamage *= 1.19f;
			player.rangedDamage *= 1.19f;
			player.magicDamage *= 1.21f;
			player.minionDamage *= 1.21f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}