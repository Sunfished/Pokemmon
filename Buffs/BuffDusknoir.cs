using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffDusknoir : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Dusknoir!");
			Description.SetDefault("+45 HP\n+20% Melee/Ranged Damage\n+13 Melee/Ranged Defense\n+13% Magic/Summon Damage\n+13 Magic/Summon Defense\n+0.2 Speed\nGhost Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Dusknoir")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedDusknoir = true;
				modPlayer.buffGhostType = true;
			}
			if (!modPlayer.summonedDusknoir || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 13;
			}
			else
			{
				player.statDefense += 13;
			}
			
			player.statLifeMax2 += 45;
			player.meleeDamage *= 1.2f;
			player.rangedDamage *= 1.2f;
			player.magicDamage *= 1.13f;
			player.minionDamage *= 1.13f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}