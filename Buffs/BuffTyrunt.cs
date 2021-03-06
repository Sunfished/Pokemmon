using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffTyrunt : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Tyrunt!");
			Description.SetDefault("+58 HP\n+17% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+9% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.2 Speed\nRock Type: Increases Knockback\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Tyrunt")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedTyrunt = true;
				modPlayer.buffRockType = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedTyrunt || modPlayer.pokemonAmount > 1) {
				modPlayer.buffRockType = false;
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
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 58;
			player.meleeDamage *= 1.17f;
			player.rangedDamage *= 1.17f;
			player.magicDamage *= 1.09f;
			player.minionDamage *= 1.09f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}