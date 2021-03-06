using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffShedinja : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Shedinja!");
			Description.SetDefault("+1 HP\n+18% Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+6% Magic/Summon Damage\n+3 Magic/Summon Defense\n+0.2 Speed\nBug Type: Unimplemented Effect\nGhost Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Shedinja")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedShedinja = true;
				modPlayer.buffBugType = true;
				modPlayer.buffGhostType = true;
			}
			if (!modPlayer.summonedShedinja || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
				modPlayer.buffGhostType = false;
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
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 1;
			player.meleeDamage *= 1.18f;
			player.rangedDamage *= 1.18f;
			player.magicDamage *= 1.06f;
			player.minionDamage *= 1.06f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}