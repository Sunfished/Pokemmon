using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffGyarados : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Gyarados!");
			Description.SetDefault("+95 HP\n+25% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+12% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.4 Speed\nWater Type: Allows swimming and water breathing\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Gyarados")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedGyarados = true;
				modPlayer.buffWaterType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedGyarados || modPlayer.pokemonAmount > 1) {
				modPlayer.buffWaterType = false;
				modPlayer.buffFlyingType = false;
				player.DelBuff(buffIndex);
				buffIndex--;
				modPlayer.pokemonAmount = 0;
			}
		
			//Calc Buffs
			var isMelee = true;
			if(player.magicDamage > player.meleeDamage || player.magicDamage > player.rangedDamage ||
			player.minionDamage > player.meleeDamage || player.minionDamage > player.rangedDamage)
				isMelee = false;
			if (isMelee)
			{
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 95;
			player.meleeDamage *= 1.25f;
			player.rangedDamage *= 1.25f;
			player.magicDamage *= 1.12f;
			player.minionDamage *= 1.12f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}