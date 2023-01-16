using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSpectrier : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Spectrier!");
			Description.SetDefault("+100 HP\n+13% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+29% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.7 Speed\nGhost Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Spectrier").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSpectrier = true;
				modPlayer.buffGhostType = true;
			}
			if (!modPlayer.summonedSpectrier || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGhostType = false;
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
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 100;
			player.GetDamage(DamageClass.Melee) *= 1.13f;
			player.GetDamage(DamageClass.Ranged) *= 1.13f;
			player.GetDamage(DamageClass.Magic) *= 1.29f;
			player.GetDamage(DamageClass.Summon) *= 1.29f;
			player.maxRunSpeed += 0.7f;
			
			//modPlayer.numSpawned++;
		}
	}
}