using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffStratagem : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Stratagem!");
			Description.SetDefault("+90 HP\n+12% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+24% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.7 Speed\nRock Type: Increases Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Stratagem").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedStratagem = true;
				modPlayer.buffRockType = true;
			}
			if (!modPlayer.summonedStratagem || modPlayer.pokemonAmount > 1) {
				modPlayer.buffRockType = false;
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
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 90;
			player.GetDamage(DamageClass.Melee) *= 1.12f;
			player.GetDamage(DamageClass.Ranged) *= 1.12f;
			player.GetDamage(DamageClass.Magic) *= 1.24f;
			player.GetDamage(DamageClass.Summon) *= 1.24f;
			player.maxRunSpeed += 0.7f;
			
			//modPlayer.numSpawned++;
		}
	}
}