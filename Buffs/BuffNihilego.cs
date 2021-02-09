using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffNihilego : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Nihilego!");
			Description.SetDefault("+109 HP\n+10% Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+25% Magic/Summon Damage\n+13 Magic/Summon Defense\n+0.5 Speed\nRock Type: Increases Knockback\nPoison Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Nihilego")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedNihilego = true;
				modPlayer.buffRockType = true;
				modPlayer.buffPoisonType = true;
			}
			if (!modPlayer.summonedNihilego || modPlayer.pokemonAmount > 1) {
				modPlayer.buffRockType = false;
				modPlayer.buffPoisonType = false;
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
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 13;
			}
			
			player.statLifeMax2 += 109;
			player.meleeDamage *= 1.1f;
			player.rangedDamage *= 1.1f;
			player.magicDamage *= 1.25f;
			player.minionDamage *= 1.25f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}