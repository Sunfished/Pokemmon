using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCinderace : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Cinderace!");
			Description.SetDefault("+80 HP\n+23% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+13% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.6 Speed\nFire Type: Lights up area");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Cinderace").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCinderace = true;
				modPlayer.buffFireType = true;
			}
			if (!modPlayer.summonedCinderace || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 80;
			player.GetDamage(DamageClass.Melee) *= 1.23f;
			player.GetDamage(DamageClass.Ranged) *= 1.23f;
			player.GetDamage(DamageClass.Magic) *= 1.13f;
			player.GetDamage(DamageClass.Summon) *= 1.13f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}