using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffThundurusTherian : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Thundurus!");
			Description.SetDefault("+79 HP\n+21% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+29% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.5 Speed\nElectric Type: Unimplemented Effect\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("ThundurusTherian")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedThundurusTherian = true;
				modPlayer.buffElectricType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedThundurusTherian || modPlayer.pokemonAmount > 1) {
				modPlayer.buffElectricType = false;
				modPlayer.buffFlyingType = false;
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
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 79;
			player.meleeDamage *= 1.21f;
			player.rangedDamage *= 1.21f;
			player.magicDamage *= 1.29f;
			player.minionDamage *= 1.29f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}