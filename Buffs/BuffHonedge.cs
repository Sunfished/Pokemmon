using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffHonedge : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Honedge!");
			Description.SetDefault("+45 HP\n+16% Melee/Ranged Damage\n+10 Melee/Ranged Defense\n+7% Magic/Summon Damage\n+3 Magic/Summon Defense\n+0.1 Speed\nSteel Type: Decreases incoming DMG by 20%\nGhost Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Honedge")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedHonedge = true;
				modPlayer.buffSteelType = true;
				modPlayer.buffGhostType = true;
			}
			if (!modPlayer.summonedHonedge || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 10;
			}
			else
			{
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 45;
			player.meleeDamage *= 1.16f;
			player.rangedDamage *= 1.16f;
			player.magicDamage *= 1.07f;
			player.minionDamage *= 1.07f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}