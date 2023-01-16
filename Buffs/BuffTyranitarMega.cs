using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffTyranitarMega : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Tyranitar!");
			Description.SetDefault("+100 HP\n+30% Melee/Ranged Damage\n+15 Melee/Ranged Defense\n+19% Magic/Summon Damage\n+12 Magic/Summon Defense\n+0.4 Speed\nRock Type: Increases Knockback\nDark Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("TyranitarMega").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedTyranitarMega = true;
				modPlayer.buffRockType = true;
				modPlayer.buffDarkType = true;
			}
			if (!modPlayer.summonedTyranitarMega || modPlayer.pokemonAmount > 1) {
				modPlayer.buffRockType = false;
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
				player.statDefense += 15;
			}
			else
			{
				player.statDefense += 12;
			}
			
			player.statLifeMax2 += 100;
			player.GetDamage(DamageClass.Melee) *= 1.3f;
			player.GetDamage(DamageClass.Ranged) *= 1.3f;
			player.GetDamage(DamageClass.Magic) *= 1.19f;
			player.GetDamage(DamageClass.Summon) *= 1.19f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}