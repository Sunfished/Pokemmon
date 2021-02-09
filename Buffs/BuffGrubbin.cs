using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffGrubbin : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Grubbin!");
			Description.SetDefault("+47 HP\n+12% Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+11% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.2 Speed\nBug Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Grubbin")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedGrubbin = true;
				modPlayer.buffBugType = true;
			}
			if (!modPlayer.summonedGrubbin || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
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
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 47;
			player.meleeDamage *= 1.12f;
			player.rangedDamage *= 1.12f;
			player.magicDamage *= 1.11f;
			player.minionDamage *= 1.11f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}