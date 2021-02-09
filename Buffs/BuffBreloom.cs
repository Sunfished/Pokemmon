using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffBreloom : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Breloom!");
			Description.SetDefault("+60 HP\n+26% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+12% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.3 Speed\nGrass Type: Regens HP during daytime\nFighting Type: Increases DMG when HP > 50%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Breloom")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedBreloom = true;
				modPlayer.buffGrassType = true;
				modPlayer.buffFightingType = true;
			}
			if (!modPlayer.summonedBreloom || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGrassType = false;
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 60;
			player.meleeDamage *= 1.26f;
			player.rangedDamage *= 1.26f;
			player.magicDamage *= 1.12f;
			player.minionDamage *= 1.12f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}