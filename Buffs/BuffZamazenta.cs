using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffZamazenta : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Zamazenta!");
			Description.SetDefault("+92 HP\n+26% Melee/Ranged Damage\n+11 Melee/Ranged Defense\n+16% Magic/Summon Damage\n+11 Magic/Summon Defense\n+0.7 Speed\nFighting Type: Increases DMG when HP > 50%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Zamazenta").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedZamazenta = true;
				modPlayer.buffFightingType = true;
			}
			if (!modPlayer.summonedZamazenta || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFightingType = false;
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
				player.statDefense += 11;
			}
			else
			{
				player.statDefense += 11;
			}
			
			player.statLifeMax2 += 92;
			player.GetDamage(DamageClass.Melee) *= 1.26f;
			player.GetDamage(DamageClass.Ranged) *= 1.26f;
			player.GetDamage(DamageClass.Magic) *= 1.16f;
			player.GetDamage(DamageClass.Summon) *= 1.16f;
			player.maxRunSpeed += 0.7f;
			
			//modPlayer.numSpawned++;
		}
	}
}