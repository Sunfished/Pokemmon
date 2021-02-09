using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffGiratinaOrigin : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Giratina!");
			Description.SetDefault("+150 HP\n+24% Melee/Ranged Damage\n+10 Melee/Ranged Defense\n+24% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.5 Speed\nGhost Type: Unimplemented Effect\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("GiratinaOrigin")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedGiratinaOrigin = true;
				modPlayer.buffGhostType = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedGiratinaOrigin || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGhostType = false;
				modPlayer.buffDragonType = false;
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
			
			player.statLifeMax2 += 150;
			player.meleeDamage *= 1.24f;
			player.rangedDamage *= 1.24f;
			player.magicDamage *= 1.24f;
			player.minionDamage *= 1.24f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}