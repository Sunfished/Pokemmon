using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffWynaut : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Wynaut!");
			Description.SetDefault("+95 HP\n+4% Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+4% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.1 Speed\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Wynaut").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedWynaut = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedWynaut || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPsychicType = false;
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
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 95;
			player.GetDamage(DamageClass.Melee) *= 1.04f;
			player.GetDamage(DamageClass.Ranged) *= 1.04f;
			player.GetDamage(DamageClass.Magic) *= 1.04f;
			player.GetDamage(DamageClass.Summon) *= 1.04f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}