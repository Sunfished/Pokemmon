using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffNosepass : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Nosepass!");
			Description.SetDefault("+30 HP\n+9% Melee/Ranged Damage\n+13 Melee/Ranged Defense\n+9% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.1 Speed\nRock Type: Increases Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Nosepass")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedNosepass = true;
				modPlayer.buffRockType = true;
			}
			if (!modPlayer.summonedNosepass || modPlayer.pokemonAmount > 1) {
				modPlayer.buffRockType = false;
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
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 30;
			player.meleeDamage *= 1.09f;
			player.rangedDamage *= 1.09f;
			player.magicDamage *= 1.09f;
			player.minionDamage *= 1.09f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}