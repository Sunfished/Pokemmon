using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMagneton : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Magneton!");
			Description.SetDefault("+50 HP\n+12% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+24% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.3 Speed\nElectric Type: Unimplemented Effect\nSteel Type: Decreases incoming DMG by 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Magneton").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMagneton = true;
				modPlayer.buffElectricType = true;
				modPlayer.buffSteelType = true;
			}
			if (!modPlayer.summonedMagneton || modPlayer.pokemonAmount > 1) {
				modPlayer.buffElectricType = false;
				modPlayer.buffSteelType = false;
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
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 50;
			player.GetDamage(DamageClass.Melee) *= 1.12f;
			player.GetDamage(DamageClass.Ranged) *= 1.12f;
			player.GetDamage(DamageClass.Magic) *= 1.24f;
			player.GetDamage(DamageClass.Summon) *= 1.24f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}