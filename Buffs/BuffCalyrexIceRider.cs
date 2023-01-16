using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCalyrexIceRider : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Calyrex!");
			Description.SetDefault("+100 HP\n+30% Melee/Ranged Damage\n+15 Melee/Ranged Defense\n+17% Magic/Summon Damage\n+13 Magic/Summon Defense\n+0.2 Speed\nPsychic Type: Regens Mana faster\nIce Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("CalyrexIceRider").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCalyrexIceRider = true;
				modPlayer.buffPsychicType = true;
				modPlayer.buffIceType = true;
			}
			if (!modPlayer.summonedCalyrexIceRider || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPsychicType = false;
				modPlayer.buffIceType = false;
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
				player.statDefense += 15;
			}
			else
			{
				player.statDefense += 13;
			}
			
			player.statLifeMax2 += 100;
			player.GetDamage(DamageClass.Melee) *= 1.3f;
			player.GetDamage(DamageClass.Ranged) *= 1.3f;
			player.GetDamage(DamageClass.Magic) *= 1.17f;
			player.GetDamage(DamageClass.Summon) *= 1.17f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}