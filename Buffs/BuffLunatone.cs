using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffLunatone : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Lunatone!");
			Description.SetDefault("+90 HP\n+11% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+19% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.3 Speed\nRock Type: Increases Knockback\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Lunatone").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedLunatone = true;
				modPlayer.buffRockType = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedLunatone || modPlayer.pokemonAmount > 1) {
				modPlayer.buffRockType = false;
				modPlayer.buffPsychicType = false;
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
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 90;
			player.GetDamage(DamageClass.Melee) *= 1.11f;
			player.GetDamage(DamageClass.Ranged) *= 1.11f;
			player.GetDamage(DamageClass.Magic) *= 1.19f;
			player.GetDamage(DamageClass.Summon) *= 1.19f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}