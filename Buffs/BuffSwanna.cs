using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSwanna : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Swanna!");
			Description.SetDefault("+75 HP\n+17% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+17% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.5 Speed\nWater Type: Allows swimming and water breathing\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Swanna")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSwanna = true;
				modPlayer.buffWaterType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedSwanna || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 75;
			player.meleeDamage *= 1.17f;
			player.rangedDamage *= 1.17f;
			player.magicDamage *= 1.17f;
			player.minionDamage *= 1.17f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}