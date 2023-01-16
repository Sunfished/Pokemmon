using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffPikachuPartner : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Pikachu!");
			Description.SetDefault("+45 HP\n+16% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+15% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.6 Speed\nElectric Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("PikachuPartner").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedPikachuPartner = true;
				modPlayer.buffElectricType = true;
			}
			if (!modPlayer.summonedPikachuPartner || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 45;
			player.GetDamage(DamageClass.Melee) *= 1.16f;
			player.GetDamage(DamageClass.Ranged) *= 1.16f;
			player.GetDamage(DamageClass.Magic) *= 1.15f;
			player.GetDamage(DamageClass.Summon) *= 1.15f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}