using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffOctillery : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Octillery!");
			Description.SetDefault("+75 HP\n+21% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+21% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.2 Speed\nWater Type: Allows swimming and water breathing");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Octillery")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedOctillery = true;
				modPlayer.buffWaterType = true;
			}
			if (!modPlayer.summonedOctillery || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 75;
			player.meleeDamage *= 1.21f;
			player.rangedDamage *= 1.21f;
			player.magicDamage *= 1.21f;
			player.minionDamage *= 1.21f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}