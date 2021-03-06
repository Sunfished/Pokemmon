using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffWishiwashiSchool : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Wishiwashi!");
			Description.SetDefault("+45 HP\n+28% Melee/Ranged Damage\n+13 Melee/Ranged Defense\n+28% Magic/Summon Damage\n+13 Magic/Summon Defense\n+0.1 Speed\nWater Type: Allows swimming and water breathing");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("WishiwashiSchool")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedWishiwashiSchool = true;
				modPlayer.buffWaterType = true;
			}
			if (!modPlayer.summonedWishiwashiSchool || modPlayer.pokemonAmount > 1) {
				modPlayer.buffWaterType = false;
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
			player.meleeDamage *= 1.28f;
			player.rangedDamage *= 1.28f;
			player.magicDamage *= 1.28f;
			player.minionDamage *= 1.28f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}