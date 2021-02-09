using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCarvanha : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Carvanha!");
			Description.SetDefault("+45 HP\n+18% Melee/Ranged Damage\n+2 Melee/Ranged Defense\n+13% Magic/Summon Damage\n+2 Magic/Summon Defense\n+0.3 Speed\nWater Type: Allows swimming and water breathing\nDark Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Carvanha")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCarvanha = true;
				modPlayer.buffWaterType = true;
				modPlayer.buffDarkType = true;
			}
			if (!modPlayer.summonedCarvanha || modPlayer.pokemonAmount > 1) {
				modPlayer.buffWaterType = false;
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
				player.statDefense += 2;
			}
			else
			{
				player.statDefense += 2;
			}
			
			player.statLifeMax2 += 45;
			player.meleeDamage *= 1.18f;
			player.rangedDamage *= 1.18f;
			player.magicDamage *= 1.13f;
			player.minionDamage *= 1.13f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}