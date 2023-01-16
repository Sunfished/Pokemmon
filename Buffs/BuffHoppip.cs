using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffHoppip : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Hoppip!");
			Description.SetDefault("+35 HP\n+7% Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+7% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.2 Speed\nGrass Type: Regens HP during daytime\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Hoppip").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedHoppip = true;
				modPlayer.buffGrassType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedHoppip || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGrassType = false;
				modPlayer.buffFlyingType = false;
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
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 35;
			player.GetDamage(DamageClass.Melee) *= 1.07f;
			player.GetDamage(DamageClass.Ranged) *= 1.07f;
			player.GetDamage(DamageClass.Magic) *= 1.07f;
			player.GetDamage(DamageClass.Summon) *= 1.07f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}