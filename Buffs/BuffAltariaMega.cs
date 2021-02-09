using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffAltariaMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Altaria!");
			Description.SetDefault("+75 HP\n+22% Melee/Ranged Damage\n+11 Melee/Ranged Defense\n+22% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.4 Speed\nDragon Type: Multitude of effects when HP < 20%\nFairy Type: Regens HP during nighttime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("AltariaMega")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedAltariaMega = true;
				modPlayer.buffDragonType = true;
				modPlayer.buffFairyType = true;
			}
			if (!modPlayer.summonedAltariaMega || modPlayer.pokemonAmount > 1) {
				modPlayer.buffDragonType = false;
				modPlayer.buffFairyType = false;
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
				player.statDefense += 11;
			}
			else
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 75;
			player.meleeDamage *= 1.22f;
			player.rangedDamage *= 1.22f;
			player.magicDamage *= 1.22f;
			player.minionDamage *= 1.22f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}