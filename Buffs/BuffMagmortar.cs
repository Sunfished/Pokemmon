using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMagmortar : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Magmortar!");
			Description.SetDefault("+75 HP\n+19% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+25% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.4 Speed\nFire Type: Lights up area");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Magmortar").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMagmortar = true;
				modPlayer.buffFireType = true;
			}
			if (!modPlayer.summonedMagmortar || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFireType = false;
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
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 75;
			player.GetDamage(DamageClass.Melee) *= 1.19f;
			player.GetDamage(DamageClass.Ranged) *= 1.19f;
			player.GetDamage(DamageClass.Magic) *= 1.25f;
			player.GetDamage(DamageClass.Summon) *= 1.25f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}