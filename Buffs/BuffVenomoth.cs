using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffVenomoth : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Venomoth!");
			Description.SetDefault("+70 HP\n+13% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+18% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.5 Speed\nBug Type: Unimplemented Effect\nPoison Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Venomoth").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedVenomoth = true;
				modPlayer.buffBugType = true;
				modPlayer.buffPoisonType = true;
			}
			if (!modPlayer.summonedVenomoth || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
				modPlayer.buffPoisonType = false;
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
			
			player.statLifeMax2 += 70;
			player.GetDamage(DamageClass.Melee) *= 1.13f;
			player.GetDamage(DamageClass.Ranged) *= 1.13f;
			player.GetDamage(DamageClass.Magic) *= 1.18f;
			player.GetDamage(DamageClass.Summon) *= 1.18f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}