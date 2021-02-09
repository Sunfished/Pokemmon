using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffShiinotic : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Shiinotic!");
			Description.SetDefault("+60 HP\n+9% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+18% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.1 Speed\nGrass Type: Regens HP during daytime\nFairy Type: Regens HP during nighttime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Shiinotic")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedShiinotic = true;
				modPlayer.buffGrassType = true;
				modPlayer.buffFairyType = true;
			}
			if (!modPlayer.summonedShiinotic || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGrassType = false;
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 60;
			player.meleeDamage *= 1.09f;
			player.rangedDamage *= 1.09f;
			player.magicDamage *= 1.18f;
			player.minionDamage *= 1.18f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}