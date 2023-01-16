using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMonferno : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Monferno!");
			Description.SetDefault("+64 HP\n+15% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+15% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.4 Speed\nFire Type: Lights up area\nFighting Type: Increases DMG when HP > 50%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Monferno").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMonferno = true;
				modPlayer.buffFireType = true;
				modPlayer.buffFightingType = true;
			}
			if (!modPlayer.summonedMonferno || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFireType = false;
				modPlayer.buffFightingType = false;
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
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 64;
			player.GetDamage(DamageClass.Melee) *= 1.15f;
			player.GetDamage(DamageClass.Ranged) *= 1.15f;
			player.GetDamage(DamageClass.Magic) *= 1.15f;
			player.GetDamage(DamageClass.Summon) *= 1.15f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}