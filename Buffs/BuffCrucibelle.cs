using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCrucibelle : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Crucibelle!");
			Description.SetDefault("+106 HP\n+21% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+15% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.5 Speed\nPoison Type: Unimplemented Effect\nRock Type: Increases Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Crucibelle")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCrucibelle = true;
				modPlayer.buffPoisonType = true;
				modPlayer.buffRockType = true;
			}
			if (!modPlayer.summonedCrucibelle || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPoisonType = false;
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
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 106;
			player.meleeDamage *= 1.21f;
			player.rangedDamage *= 1.21f;
			player.magicDamage *= 1.15f;
			player.minionDamage *= 1.15f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}