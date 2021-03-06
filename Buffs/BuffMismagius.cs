using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMismagius : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Mismagius!");
			Description.SetDefault("+60 HP\n+12% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+21% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.5 Speed\nGhost Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Mismagius")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMismagius = true;
				modPlayer.buffGhostType = true;
			}
			if (!modPlayer.summonedMismagius || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGhostType = false;
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
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 60;
			player.meleeDamage *= 1.12f;
			player.rangedDamage *= 1.12f;
			player.magicDamage *= 1.21f;
			player.minionDamage *= 1.21f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}