using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffShuppet : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Shuppet!");
			Description.SetDefault("+44 HP\n+15% Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+12% Magic/Summon Damage\n+3 Magic/Summon Defense\n+0.2 Speed\nGhost Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Shuppet")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedShuppet = true;
				modPlayer.buffGhostType = true;
			}
			if (!modPlayer.summonedShuppet || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 44;
			player.meleeDamage *= 1.15f;
			player.rangedDamage *= 1.15f;
			player.magicDamage *= 1.12f;
			player.minionDamage *= 1.12f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}