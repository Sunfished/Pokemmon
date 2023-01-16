using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCacturne : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Cacturne!");
			Description.SetDefault("+70 HP\n+23% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+23% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.3 Speed\nGrass Type: Regens HP during daytime\nDark Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Cacturne").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCacturne = true;
				modPlayer.buffGrassType = true;
				modPlayer.buffDarkType = true;
			}
			if (!modPlayer.summonedCacturne || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGrassType = false;
				modPlayer.buffDarkType = false;
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
			
			player.statLifeMax2 += 70;
			player.GetDamage(DamageClass.Melee) *= 1.23f;
			player.GetDamage(DamageClass.Ranged) *= 1.23f;
			player.GetDamage(DamageClass.Magic) *= 1.23f;
			player.GetDamage(DamageClass.Summon) *= 1.23f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}