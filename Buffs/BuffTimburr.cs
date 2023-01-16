using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffTimburr : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Timburr!");
			Description.SetDefault("+75 HP\n+16% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+5% Magic/Summon Damage\n+3 Magic/Summon Defense\n+0.2 Speed\nFighting Type: Increases DMG when HP > 50%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Timburr").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedTimburr = true;
				modPlayer.buffFightingType = true;
			}
			if (!modPlayer.summonedTimburr || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 75;
			player.GetDamage(DamageClass.Melee) *= 1.16f;
			player.GetDamage(DamageClass.Ranged) *= 1.16f;
			player.GetDamage(DamageClass.Magic) *= 1.05f;
			player.GetDamage(DamageClass.Summon) *= 1.05f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}