using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffJoltik : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Joltik!");
			Description.SetDefault("+50 HP\n+9% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+11% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.3 Speed\nBug Type: Unimplemented Effect\nElectric Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Joltik")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedJoltik = true;
				modPlayer.buffBugType = true;
				modPlayer.buffElectricType = true;
			}
			if (!modPlayer.summonedJoltik || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
				modPlayer.buffElectricType = false;
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
			
			player.statLifeMax2 += 50;
			player.meleeDamage *= 1.09f;
			player.rangedDamage *= 1.09f;
			player.magicDamage *= 1.11f;
			player.minionDamage *= 1.11f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}