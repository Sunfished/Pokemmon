using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffGreninja : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Greninja!");
			Description.SetDefault("+72 HP\n+19% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+20% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.6 Speed\nWater Type: Allows swimming and water breathing\nDark Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Greninja").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedGreninja = true;
				modPlayer.buffWaterType = true;
				modPlayer.buffDarkType = true;
			}
			if (!modPlayer.summonedGreninja || modPlayer.pokemonAmount > 1) {
				modPlayer.buffWaterType = false;
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
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 72;
			player.GetDamage(DamageClass.Melee) *= 1.19f;
			player.GetDamage(DamageClass.Ranged) *= 1.19f;
			player.GetDamage(DamageClass.Magic) *= 1.2f;
			player.GetDamage(DamageClass.Summon) *= 1.2f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}