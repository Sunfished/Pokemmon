using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMusharna : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Musharna!");
			Description.SetDefault("+116 HP\n+11% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+21% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.1 Speed\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Musharna").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMusharna = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedMusharna || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 116;
			player.GetDamage(DamageClass.Melee) *= 1.11f;
			player.GetDamage(DamageClass.Ranged) *= 1.11f;
			player.GetDamage(DamageClass.Magic) *= 1.21f;
			player.GetDamage(DamageClass.Summon) *= 1.21f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}