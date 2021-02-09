using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffBewear : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Bewear!");
			Description.SetDefault("+120 HP\n+25% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+11% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.3 Speed\nNormal Type: Unimplemented Effect\nFighting Type: Increases DMG when HP > 50%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Bewear")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedBewear = true;
				modPlayer.buffNormalType = true;
				modPlayer.buffFightingType = true;
			}
			if (!modPlayer.summonedBewear || modPlayer.pokemonAmount > 1) {
				modPlayer.buffNormalType = false;
				modPlayer.buffFightingType = false;
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 120;
			player.meleeDamage *= 1.25f;
			player.rangedDamage *= 1.25f;
			player.magicDamage *= 1.11f;
			player.minionDamage *= 1.11f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}