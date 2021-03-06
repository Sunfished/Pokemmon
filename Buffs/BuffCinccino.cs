using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCinccino : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Cinccino!");
			Description.SetDefault("+75 HP\n+19% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+13% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.6 Speed\nNormal Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Cinccino")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCinccino = true;
				modPlayer.buffNormalType = true;
			}
			if (!modPlayer.summonedCinccino || modPlayer.pokemonAmount > 1) {
				modPlayer.buffNormalType = false;
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
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 75;
			player.meleeDamage *= 1.19f;
			player.rangedDamage *= 1.19f;
			player.magicDamage *= 1.13f;
			player.minionDamage *= 1.13f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}