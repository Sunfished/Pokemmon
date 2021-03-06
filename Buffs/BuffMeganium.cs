using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMeganium : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Meganium!");
			Description.SetDefault("+80 HP\n+16% Melee/Ranged Damage\n+10 Melee/Ranged Defense\n+16% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.4 Speed\nGrass Type: Regens HP during daytime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Meganium")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMeganium = true;
				modPlayer.buffGrassType = true;
			}
			if (!modPlayer.summonedMeganium || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 10;
			}
			else
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 80;
			player.meleeDamage *= 1.16f;
			player.rangedDamage *= 1.16f;
			player.magicDamage *= 1.16f;
			player.minionDamage *= 1.16f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}