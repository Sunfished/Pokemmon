using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffTurtwig : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Turtwig!");
			Description.SetDefault("+55 HP\n+13% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+9% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.2 Speed\nGrass Type: Regens HP during daytime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Turtwig").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedTurtwig = true;
				modPlayer.buffGrassType = true;
			}
			if (!modPlayer.summonedTurtwig || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGrassType = false;
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
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 55;
			player.GetDamage(DamageClass.Melee) *= 1.13f;
			player.GetDamage(DamageClass.Ranged) *= 1.13f;
			player.GetDamage(DamageClass.Magic) *= 1.09f;
			player.GetDamage(DamageClass.Summon) *= 1.09f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}