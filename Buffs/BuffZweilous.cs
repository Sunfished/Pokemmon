using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffZweilous : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Zweilous!");
			Description.SetDefault("+72 HP\n+17% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+13% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.3 Speed\nDark Type: Unimplemented Effect\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Zweilous").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedZweilous = true;
				modPlayer.buffDarkType = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedZweilous || modPlayer.pokemonAmount > 1) {
				modPlayer.buffDarkType = false;
				modPlayer.buffDragonType = false;
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
			
			player.statLifeMax2 += 72;
			player.GetDamage(DamageClass.Melee) *= 1.17f;
			player.GetDamage(DamageClass.Ranged) *= 1.17f;
			player.GetDamage(DamageClass.Magic) *= 1.13f;
			player.GetDamage(DamageClass.Summon) *= 1.13f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}