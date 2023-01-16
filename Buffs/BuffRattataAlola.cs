using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffRattataAlola : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Rattata!");
			Description.SetDefault("+30 HP\n+11% Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+5% Magic/Summon Damage\n+3 Magic/Summon Defense\n+0.4 Speed\nDark Type: Unimplemented Effect\nNormal Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("RattataAlola").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedRattataAlola = true;
				modPlayer.buffDarkType = true;
				modPlayer.buffNormalType = true;
			}
			if (!modPlayer.summonedRattataAlola || modPlayer.pokemonAmount > 1) {
				modPlayer.buffDarkType = false;
				modPlayer.buffNormalType = false;
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
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 30;
			player.GetDamage(DamageClass.Melee) *= 1.11f;
			player.GetDamage(DamageClass.Ranged) *= 1.11f;
			player.GetDamage(DamageClass.Magic) *= 1.05f;
			player.GetDamage(DamageClass.Summon) *= 1.05f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}