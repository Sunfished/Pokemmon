using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffKirlia : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Kirlia!");
			Description.SetDefault("+38 HP\n+7% Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+13% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.2 Speed\nPsychic Type: Regens Mana faster\nFairy Type: Regens HP during nighttime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Kirlia").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedKirlia = true;
				modPlayer.buffPsychicType = true;
				modPlayer.buffFairyType = true;
			}
			if (!modPlayer.summonedKirlia || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPsychicType = false;
				modPlayer.buffFairyType = false;
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
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 38;
			player.GetDamage(DamageClass.Melee) *= 1.07f;
			player.GetDamage(DamageClass.Ranged) *= 1.07f;
			player.GetDamage(DamageClass.Magic) *= 1.13f;
			player.GetDamage(DamageClass.Summon) *= 1.13f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}