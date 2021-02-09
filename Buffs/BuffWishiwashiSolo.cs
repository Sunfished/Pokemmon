using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffWishiwashiSolo : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Wishiwashi!");
			Description.SetDefault("+45 HP\n+4% Melee/Ranged Damage\n+2 Melee/Ranged Defense\n+5% Magic/Summon Damage\n+2 Magic/Summon Defense\n+0.2 Speed\nWater Type: Allows swimming and water breathing");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("WishiwashiSolo")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedWishiwashiSolo = true;
				modPlayer.buffWaterType = true;
			}
			if (!modPlayer.summonedWishiwashiSolo || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 2;
			}
			else
			{
				player.statDefense += 2;
			}
			
			player.statLifeMax2 += 45;
			player.meleeDamage *= 1.04f;
			player.rangedDamage *= 1.04f;
			player.magicDamage *= 1.05f;
			player.minionDamage *= 1.05f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}