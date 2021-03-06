using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMantine : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Mantine!");
			Description.SetDefault("+85 HP\n+8% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+16% Magic/Summon Damage\n+14 Magic/Summon Defense\n+0.3 Speed\nWater Type: Allows swimming and water breathing\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Mantine")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMantine = true;
				modPlayer.buffWaterType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedMantine || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 14;
			}
			
			player.statLifeMax2 += 85;
			player.meleeDamage *= 1.08f;
			player.rangedDamage *= 1.08f;
			player.magicDamage *= 1.16f;
			player.minionDamage *= 1.16f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}