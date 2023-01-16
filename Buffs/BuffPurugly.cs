using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffPurugly : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Purugly!");
			Description.SetDefault("+71 HP\n+16% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+12% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.6 Speed\nNormal Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Purugly").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedPurugly = true;
				modPlayer.buffNormalType = true;
			}
			if (!modPlayer.summonedPurugly || modPlayer.pokemonAmount > 1) {
				modPlayer.buffNormalType = false;
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
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 71;
			player.GetDamage(DamageClass.Melee) *= 1.16f;
			player.GetDamage(DamageClass.Ranged) *= 1.16f;
			player.GetDamage(DamageClass.Magic) *= 1.12f;
			player.GetDamage(DamageClass.Summon) *= 1.12f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}