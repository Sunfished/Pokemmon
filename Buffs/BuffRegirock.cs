using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffRegirock : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Regirock!");
			Description.SetDefault("+80 HP\n+20% Melee/Ranged Damage\n+20 Melee/Ranged Defense\n+10% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.2 Speed\nRock Type: Increases Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Regirock")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedRegirock = true;
				modPlayer.buffRockType = true;
			}
			if (!modPlayer.summonedRegirock || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 20;
			}
			else
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 80;
			player.meleeDamage *= 1.2f;
			player.rangedDamage *= 1.2f;
			player.magicDamage *= 1.1f;
			player.minionDamage *= 1.1f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}