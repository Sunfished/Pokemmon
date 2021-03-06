using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffDwebble : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Dwebble!");
			Description.SetDefault("+50 HP\n+13% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+7% Magic/Summon Damage\n+3 Magic/Summon Defense\n+0.3 Speed\nBug Type: Unimplemented Effect\nRock Type: Increases Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Dwebble")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedDwebble = true;
				modPlayer.buffBugType = true;
				modPlayer.buffRockType = true;
			}
			if (!modPlayer.summonedDwebble || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
				modPlayer.buffRockType = false;
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 50;
			player.meleeDamage *= 1.13f;
			player.rangedDamage *= 1.13f;
			player.magicDamage *= 1.07f;
			player.minionDamage *= 1.07f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}