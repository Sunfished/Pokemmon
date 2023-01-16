using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSalazzle : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Salazzle!");
			Description.SetDefault("+68 HP\n+12% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+22% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.6 Speed\nPoison Type: Unimplemented Effect\nFire Type: Lights up area");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Salazzle").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSalazzle = true;
				modPlayer.buffPoisonType = true;
				modPlayer.buffFireType = true;
			}
			if (!modPlayer.summonedSalazzle || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPoisonType = false;
				modPlayer.buffFireType = false;
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
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 68;
			player.GetDamage(DamageClass.Melee) *= 1.12f;
			player.GetDamage(DamageClass.Ranged) *= 1.12f;
			player.GetDamage(DamageClass.Magic) *= 1.22f;
			player.GetDamage(DamageClass.Summon) *= 1.22f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}