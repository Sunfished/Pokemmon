using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMewtwo : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Mewtwo!");
			Description.SetDefault("+106 HP\n+22% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+30% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.7 Speed\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Mewtwo").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMewtwo = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedMewtwo || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 106;
			player.GetDamage(DamageClass.Melee) *= 1.22f;
			player.GetDamage(DamageClass.Ranged) *= 1.22f;
			player.GetDamage(DamageClass.Magic) *= 1.3f;
			player.GetDamage(DamageClass.Summon) *= 1.3f;
			player.maxRunSpeed += 0.7f;
			
			//modPlayer.numSpawned++;
		}
	}
}