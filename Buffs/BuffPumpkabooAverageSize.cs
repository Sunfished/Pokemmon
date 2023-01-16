using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffPumpkabooAverageSize : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Pumpkaboo!");
			Description.SetDefault("+49 HP\n+13% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+8% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.3 Speed\nGhost Type: Unimplemented Effect\nGrass Type: Regens HP during daytime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("PumpkabooAverageSize").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedPumpkabooAverageSize = true;
				modPlayer.buffGhostType = true;
				modPlayer.buffGrassType = true;
			}
			if (!modPlayer.summonedPumpkabooAverageSize || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGhostType = false;
				modPlayer.buffGrassType = false;
				player.DelBuff(buffIndex);
				buffIndex--;
				modPlayer.pokemonAmount = 0;
			}
		
			//Calc Buffs
			var isMelee = true;
			if(player.GetDamage(DamageClass.Magic).Flat > player.GetDamage(DamageClass.Melee).Flat || player.GetDamage(DamageClass.Magic).Flat > player.GetDamage(DamageClass.Ranged).Flat ||
			player.GetDamage(DamageClass.Summon).Flat > player.GetDamage(DamageClass.Melee).Flat || player.GetDamage(DamageClass.Summon).Flat > player.GetDamage(DamageClass.Ranged).Flat)
				isMelee = false;
			if (isMelee)
			{
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 49;
			player.GetDamage(DamageClass.Melee) *= 1.13f;
			player.GetDamage(DamageClass.Ranged) *= 1.13f;
			player.GetDamage(DamageClass.Magic) *= 1.08f;
			player.GetDamage(DamageClass.Summon) *= 1.08f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}