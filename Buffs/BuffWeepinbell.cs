using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffWeepinbell : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Weepinbell!");
			Description.SetDefault("+65 HP\n+18% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+17% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.3 Speed\nGrass Type: Regens HP during daytime\nPoison Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Weepinbell")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedWeepinbell = true;
				modPlayer.buffGrassType = true;
				modPlayer.buffPoisonType = true;
			}
			if (!modPlayer.summonedWeepinbell || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGrassType = false;
				modPlayer.buffPoisonType = false;
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
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 65;
			player.meleeDamage *= 1.18f;
			player.rangedDamage *= 1.18f;
			player.magicDamage *= 1.17f;
			player.minionDamage *= 1.17f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}