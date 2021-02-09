using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSceptileMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Sceptile!");
			Description.SetDefault("+70 HP\n+22% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+29% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.7 Speed\nGrass Type: Regens HP during daytime\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("SceptileMega")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSceptileMega = true;
				modPlayer.buffGrassType = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedSceptileMega || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGrassType = false;
				modPlayer.buffDragonType = false;
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
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 70;
			player.meleeDamage *= 1.22f;
			player.rangedDamage *= 1.22f;
			player.magicDamage *= 1.29f;
			player.minionDamage *= 1.29f;
			player.maxRunSpeed += 0.7f;
			
			//modPlayer.numSpawned++;
		}
	}
}