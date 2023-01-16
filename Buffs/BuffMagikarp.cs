using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMagikarp : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Magikarp!");
			Description.SetDefault("+20 HP\n+2% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+3% Magic/Summon Damage\n+2 Magic/Summon Defense\n+0.4 Speed\nWater Type: Allows swimming and water breathing");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Magikarp").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMagikarp = true;
				modPlayer.buffWaterType = true;
			}
			if (!modPlayer.summonedMagikarp || modPlayer.pokemonAmount > 1) {
				modPlayer.buffWaterType = false;
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 2;
			}
			
			player.statLifeMax2 += 20;
			player.GetDamage(DamageClass.Melee) *= 1.02f;
			player.GetDamage(DamageClass.Ranged) *= 1.02f;
			player.GetDamage(DamageClass.Magic) *= 1.03f;
			player.GetDamage(DamageClass.Summon) *= 1.03f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}