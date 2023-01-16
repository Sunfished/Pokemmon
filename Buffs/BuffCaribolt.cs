using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCaribolt : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Caribolt!");
			Description.SetDefault("+84 HP\n+21% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+15% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.5 Speed\nGrass Type: Regens HP during daytime\nElectric Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Caribolt").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCaribolt = true;
				modPlayer.buffGrassType = true;
				modPlayer.buffElectricType = true;
			}
			if (!modPlayer.summonedCaribolt || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 84;
			player.GetDamage(DamageClass.Melee) *= 1.21f;
			player.GetDamage(DamageClass.Ranged) *= 1.21f;
			player.GetDamage(DamageClass.Magic) *= 1.15f;
			player.GetDamage(DamageClass.Summon) *= 1.15f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}