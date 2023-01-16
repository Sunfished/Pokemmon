using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffStunky : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Stunky!");
			Description.SetDefault("+63 HP\n+12% Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+8% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.4 Speed\nPoison Type: Unimplemented Effect\nDark Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Stunky").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedStunky = true;
				modPlayer.buffPoisonType = true;
				modPlayer.buffDarkType = true;
			}
			if (!modPlayer.summonedStunky || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPoisonType = false;
				modPlayer.buffDarkType = false;
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
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 63;
			player.GetDamage(DamageClass.Melee) *= 1.12f;
			player.GetDamage(DamageClass.Ranged) *= 1.12f;
			player.GetDamage(DamageClass.Magic) *= 1.08f;
			player.GetDamage(DamageClass.Summon) *= 1.08f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}