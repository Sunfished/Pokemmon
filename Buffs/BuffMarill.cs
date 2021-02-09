using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMarill : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Marill!");
			Description.SetDefault("+70 HP\n+4% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+4% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.2 Speed\nWater Type: Allows swimming and water breathing\nFairy Type: Regens HP during nighttime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Marill")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMarill = true;
				modPlayer.buffWaterType = true;
				modPlayer.buffFairyType = true;
			}
			if (!modPlayer.summonedMarill || modPlayer.pokemonAmount > 1) {
				modPlayer.buffWaterType = false;
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 70;
			player.meleeDamage *= 1.04f;
			player.rangedDamage *= 1.04f;
			player.magicDamage *= 1.04f;
			player.minionDamage *= 1.04f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}