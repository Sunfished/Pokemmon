using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffDarmanitanZenMode : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Darmanitan!");
			Description.SetDefault("+105 HP\n+6% Melee/Ranged Damage\n+10 Melee/Ranged Defense\n+28% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.3 Speed\nFire Type: Lights up area\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("DarmanitanZenMode").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedDarmanitanZenMode = true;
				modPlayer.buffFireType = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedDarmanitanZenMode || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFireType = false;
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
				player.statDefense += 10;
			}
			else
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 105;
			player.GetDamage(DamageClass.Melee) *= 1.06f;
			player.GetDamage(DamageClass.Ranged) *= 1.06f;
			player.GetDamage(DamageClass.Magic) *= 1.28f;
			player.GetDamage(DamageClass.Summon) *= 1.28f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}