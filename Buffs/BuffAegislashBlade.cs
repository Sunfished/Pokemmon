using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffAegislashBlade : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Aegislash!");
			Description.SetDefault("+60 HP\n+28% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+28% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.3 Speed\nSteel Type: Decreases incoming DMG by 20%\nGhost Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("AegislashBlade")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedAegislashBlade = true;
				modPlayer.buffSteelType = true;
				modPlayer.buffGhostType = true;
			}
			if (!modPlayer.summonedAegislashBlade || modPlayer.pokemonAmount > 1) {
				modPlayer.buffSteelType = false;
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 60;
			player.meleeDamage *= 1.28f;
			player.rangedDamage *= 1.28f;
			player.magicDamage *= 1.28f;
			player.minionDamage *= 1.28f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}