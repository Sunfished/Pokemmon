using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSmoochum : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Smoochum!");
			Description.SetDefault("+45 HP\n+6% Melee/Ranged Damage\n+1 Melee/Ranged Defense\n+17% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.3 Speed\nIce Type: Unimplemented Effect\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Smoochum").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSmoochum = true;
				modPlayer.buffIceType = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedSmoochum || modPlayer.pokemonAmount > 1) {
				modPlayer.buffIceType = false;
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
				player.statDefense += 1;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 45;
			player.GetDamage(DamageClass.Melee) *= 1.06f;
			player.GetDamage(DamageClass.Ranged) *= 1.06f;
			player.GetDamage(DamageClass.Magic) *= 1.17f;
			player.GetDamage(DamageClass.Summon) *= 1.17f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}