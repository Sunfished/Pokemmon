using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMagearnaOriginal : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Magearna!");
			Description.SetDefault("+80 HP\n+19% Melee/Ranged Damage\n+11 Melee/Ranged Defense\n+26% Magic/Summon Damage\n+11 Magic/Summon Defense\n+0.3 Speed\nSteel Type: Decreases incoming DMG by 20%\nFairy Type: Regens HP during nighttime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("MagearnaOriginal").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMagearnaOriginal = true;
				modPlayer.buffSteelType = true;
				modPlayer.buffFairyType = true;
			}
			if (!modPlayer.summonedMagearnaOriginal || modPlayer.pokemonAmount > 1) {
				modPlayer.buffSteelType = false;
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
				player.statDefense += 11;
			}
			else
			{
				player.statDefense += 11;
			}
			
			player.statLifeMax2 += 80;
			player.GetDamage(DamageClass.Melee) *= 1.19f;
			player.GetDamage(DamageClass.Ranged) *= 1.19f;
			player.GetDamage(DamageClass.Magic) *= 1.26f;
			player.GetDamage(DamageClass.Summon) *= 1.26f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}