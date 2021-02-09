using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffLotad : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Lotad!");
			Description.SetDefault("+40 HP\n+6% Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+8% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.1 Speed\nWater Type: Allows swimming and water breathing\nGrass Type: Regens HP during daytime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Lotad")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedLotad = true;
				modPlayer.buffWaterType = true;
				modPlayer.buffGrassType = true;
			}
			if (!modPlayer.summonedLotad || modPlayer.pokemonAmount > 1) {
				modPlayer.buffWaterType = false;
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
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 40;
			player.meleeDamage *= 1.06f;
			player.rangedDamage *= 1.06f;
			player.magicDamage *= 1.08f;
			player.minionDamage *= 1.08f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}