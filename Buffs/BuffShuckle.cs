using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffShuckle : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Shuckle!");
			Description.SetDefault("+20 HP\n+2% Melee/Ranged Damage\n+23 Melee/Ranged Defense\n+2% Magic/Summon Damage\n+23 Magic/Summon Defense\n+0.0 Speed\nBug Type: Unimplemented Effect\nRock Type: Increases Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Shuckle")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedShuckle = true;
				modPlayer.buffBugType = true;
				modPlayer.buffRockType = true;
			}
			if (!modPlayer.summonedShuckle || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 23;
			}
			else
			{
				player.statDefense += 23;
			}
			
			player.statLifeMax2 += 20;
			player.meleeDamage *= 1.02f;
			player.rangedDamage *= 1.02f;
			player.magicDamage *= 1.02f;
			player.minionDamage *= 1.02f;
			player.maxRunSpeed += 0.0f;
			
			//modPlayer.numSpawned++;
		}
	}
}