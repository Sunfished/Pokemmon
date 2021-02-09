using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffRillaboom : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Rillaboom!");
			Description.SetDefault("+100 HP\n+25% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+12% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.4 Speed\nGrass Type: Regens HP during daytime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Rillaboom")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedRillaboom = true;
				modPlayer.buffGrassType = true;
			}
			if (!modPlayer.summonedRillaboom || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 100;
			player.meleeDamage *= 1.25f;
			player.rangedDamage *= 1.25f;
			player.magicDamage *= 1.12f;
			player.minionDamage *= 1.12f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}