using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffFurfrou : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Furfrou!");
			Description.SetDefault("+75 HP\n+16% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+13% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.5 Speed\nNormal Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Furfrou").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedFurfrou = true;
				modPlayer.buffNormalType = true;
			}
			if (!modPlayer.summonedFurfrou || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 75;
			player.GetDamage(DamageClass.Melee) *= 1.16f;
			player.GetDamage(DamageClass.Ranged) *= 1.16f;
			player.GetDamage(DamageClass.Magic) *= 1.13f;
			player.GetDamage(DamageClass.Summon) *= 1.13f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}