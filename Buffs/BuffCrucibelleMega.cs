using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCrucibelleMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Crucibelle!");
			Description.SetDefault("+106 HP\n+27% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+17% Magic/Summon Damage\n+12 Magic/Summon Defense\n+0.6 Speed\nPoison Type: Unimplemented Effect\nRock Type: Increases Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("CrucibelleMega")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCrucibelleMega = true;
				modPlayer.buffPoisonType = true;
				modPlayer.buffRockType = true;
			}
			if (!modPlayer.summonedCrucibelleMega || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 12;
			}
			
			player.statLifeMax2 += 106;
			player.meleeDamage *= 1.27f;
			player.rangedDamage *= 1.27f;
			player.magicDamage *= 1.17f;
			player.minionDamage *= 1.17f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}