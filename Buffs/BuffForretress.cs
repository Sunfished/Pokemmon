using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffForretress : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Forretress!");
			Description.SetDefault("+75 HP\n+18% Melee/Ranged Damage\n+14 Melee/Ranged Defense\n+12% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.2 Speed\nBug Type: Unimplemented Effect\nSteel Type: Decreases incoming DMG by 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Forretress")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedForretress = true;
				modPlayer.buffBugType = true;
				modPlayer.buffSteelType = true;
			}
			if (!modPlayer.summonedForretress || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
				modPlayer.buffSteelType = false;
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
				player.statDefense += 14;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 75;
			player.meleeDamage *= 1.18f;
			player.rangedDamage *= 1.18f;
			player.magicDamage *= 1.12f;
			player.minionDamage *= 1.12f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}