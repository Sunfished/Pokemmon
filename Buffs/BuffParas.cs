using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffParas : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Paras!");
			Description.SetDefault("+35 HP\n+14% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+9% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.1 Speed\nBug Type: Unimplemented Effect\nGrass Type: Regens HP during daytime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Paras")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedParas = true;
				modPlayer.buffBugType = true;
				modPlayer.buffGrassType = true;
			}
			if (!modPlayer.summonedParas || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
				modPlayer.buffGrassType = false;
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 35;
			player.meleeDamage *= 1.14f;
			player.rangedDamage *= 1.14f;
			player.magicDamage *= 1.09f;
			player.minionDamage *= 1.09f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}