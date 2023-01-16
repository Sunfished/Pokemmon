using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCresselia : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Cresselia!");
			Description.SetDefault("+120 HP\n+14% Melee/Ranged Damage\n+12 Melee/Ranged Defense\n+15% Magic/Summon Damage\n+13 Magic/Summon Defense\n+0.4 Speed\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Cresselia").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCresselia = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedCresselia || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 12;
			}
			else
			{
				player.statDefense += 13;
			}
			
			player.statLifeMax2 += 120;
			player.GetDamage(DamageClass.Melee) *= 1.14f;
			player.GetDamage(DamageClass.Ranged) *= 1.14f;
			player.GetDamage(DamageClass.Magic) *= 1.15f;
			player.GetDamage(DamageClass.Summon) *= 1.15f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}