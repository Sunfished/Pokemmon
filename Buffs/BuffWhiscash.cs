using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffWhiscash : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Whiscash!");
			Description.SetDefault("+110 HP\n+15% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+15% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.3 Speed\nWater Type: Allows swimming and water breathing\nGround Type: Nullifies Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Whiscash")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedWhiscash = true;
				modPlayer.buffWaterType = true;
				modPlayer.buffGroundType = true;
			}
			if (!modPlayer.summonedWhiscash || modPlayer.pokemonAmount > 1) {
				modPlayer.buffWaterType = false;
				modPlayer.buffGroundType = false;
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
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 110;
			player.meleeDamage *= 1.15f;
			player.rangedDamage *= 1.15f;
			player.magicDamage *= 1.15f;
			player.minionDamage *= 1.15f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}