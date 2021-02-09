using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffJumbao : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Jumbao!");
			Description.SetDefault("+92 HP\n+12% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+24% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.5 Speed\nGrass Type: Regens HP during daytime\nFairy Type: Regens HP during nighttime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Jumbao")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedJumbao = true;
				modPlayer.buffGrassType = true;
				modPlayer.buffFairyType = true;
			}
			if (!modPlayer.summonedJumbao || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGrassType = false;
				modPlayer.buffFairyType = false;
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
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 92;
			player.meleeDamage *= 1.12f;
			player.rangedDamage *= 1.12f;
			player.magicDamage *= 1.24f;
			player.minionDamage *= 1.24f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}