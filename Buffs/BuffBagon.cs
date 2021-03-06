using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffBagon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Bagon!");
			Description.SetDefault("+45 HP\n+15% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+8% Magic/Summon Damage\n+3 Magic/Summon Defense\n+0.2 Speed\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Bagon")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedBagon = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedBagon || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 45;
			player.meleeDamage *= 1.15f;
			player.rangedDamage *= 1.15f;
			player.magicDamage *= 1.08f;
			player.minionDamage *= 1.08f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}