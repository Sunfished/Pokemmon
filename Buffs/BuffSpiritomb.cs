using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSpiritomb : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Spiritomb!");
			Description.SetDefault("+50 HP\n+18% Melee/Ranged Damage\n+10 Melee/Ranged Defense\n+18% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.2 Speed\nGhost Type: Unimplemented Effect\nDark Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Spiritomb")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSpiritomb = true;
				modPlayer.buffGhostType = true;
				modPlayer.buffDarkType = true;
			}
			if (!modPlayer.summonedSpiritomb || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGhostType = false;
				modPlayer.buffDarkType = false;
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
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 50;
			player.meleeDamage *= 1.18f;
			player.rangedDamage *= 1.18f;
			player.magicDamage *= 1.18f;
			player.minionDamage *= 1.18f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}