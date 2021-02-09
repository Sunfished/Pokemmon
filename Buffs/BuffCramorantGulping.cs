using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCramorantGulping : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Cramorant!");
			Description.SetDefault("+70 HP\n+17% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+17% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.4 Speed\nFlying Type: Descends slowly in the air\nWater Type: Allows swimming and water breathing");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("CramorantGulping")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCramorantGulping = true;
				modPlayer.buffFlyingType = true;
				modPlayer.buffWaterType = true;
			}
			if (!modPlayer.summonedCramorantGulping || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFlyingType = false;
				modPlayer.buffWaterType = false;
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 70;
			player.meleeDamage *= 1.17f;
			player.rangedDamage *= 1.17f;
			player.magicDamage *= 1.17f;
			player.minionDamage *= 1.17f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}