using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSunkern : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Sunkern!");
			Description.SetDefault("+30 HP\n+6% Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+6% Magic/Summon Damage\n+3 Magic/Summon Defense\n+0.1 Speed\nGrass Type: Regens HP during daytime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Sunkern")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSunkern = true;
				modPlayer.buffGrassType = true;
			}
			if (!modPlayer.summonedSunkern || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 30;
			player.meleeDamage *= 1.06f;
			player.rangedDamage *= 1.06f;
			player.magicDamage *= 1.06f;
			player.minionDamage *= 1.06f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}