using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffExeggutorAlola : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Exeggutor!");
			Description.SetDefault("+95 HP\n+21% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+25% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.2 Speed\nGrass Type: Regens HP during daytime\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("ExeggutorAlola")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedExeggutorAlola = true;
				modPlayer.buffGrassType = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedExeggutorAlola || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGrassType = false;
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 95;
			player.meleeDamage *= 1.21f;
			player.rangedDamage *= 1.21f;
			player.magicDamage *= 1.25f;
			player.minionDamage *= 1.25f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}