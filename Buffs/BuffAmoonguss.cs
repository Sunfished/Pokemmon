using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffAmoonguss : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Amoonguss!");
			Description.SetDefault("+114 HP\n+17% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+17% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.1 Speed\nGrass Type: Regens HP during daytime\nPoison Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Amoonguss").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedAmoonguss = true;
				modPlayer.buffGrassType = true;
				modPlayer.buffPoisonType = true;
			}
			if (!modPlayer.summonedAmoonguss || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGrassType = false;
				modPlayer.buffPoisonType = false;
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
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 114;
			player.GetDamage(DamageClass.Melee) *= 1.17f;
			player.GetDamage(DamageClass.Ranged) *= 1.17f;
			player.GetDamage(DamageClass.Magic) *= 1.17f;
			player.GetDamage(DamageClass.Summon) *= 1.17f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}