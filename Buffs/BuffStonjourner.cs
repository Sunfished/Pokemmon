using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffStonjourner : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Stonjourner!");
			Description.SetDefault("+100 HP\n+25% Melee/Ranged Damage\n+13 Melee/Ranged Defense\n+4% Magic/Summon Damage\n+2 Magic/Summon Defense\n+0.3 Speed\nRock Type: Increases Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Stonjourner")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedStonjourner = true;
				modPlayer.buffRockType = true;
			}
			if (!modPlayer.summonedStonjourner || modPlayer.pokemonAmount > 1) {
				modPlayer.buffRockType = false;
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
				player.statDefense += 13;
			}
			else
			{
				player.statDefense += 2;
			}
			
			player.statLifeMax2 += 100;
			player.meleeDamage *= 1.25f;
			player.rangedDamage *= 1.25f;
			player.magicDamage *= 1.04f;
			player.minionDamage *= 1.04f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}