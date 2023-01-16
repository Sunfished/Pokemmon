using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffElectrelk : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Electrelk!");
			Description.SetDefault("+59 HP\n+16% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+11% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.5 Speed\nGrass Type: Regens HP during daytime\nElectric Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Electrelk").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedElectrelk = true;
				modPlayer.buffGrassType = true;
				modPlayer.buffElectricType = true;
			}
			if (!modPlayer.summonedElectrelk || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGrassType = false;
				modPlayer.buffElectricType = false;
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
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 59;
			player.GetDamage(DamageClass.Melee) *= 1.16f;
			player.GetDamage(DamageClass.Ranged) *= 1.16f;
			player.GetDamage(DamageClass.Magic) *= 1.11f;
			player.GetDamage(DamageClass.Summon) *= 1.11f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}