using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffFawnifer : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Fawnifer!");
			Description.SetDefault("+49 HP\n+12% Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+10% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.4 Speed\nGrass Type: Regens HP during daytime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Fawnifer")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedFawnifer = true;
				modPlayer.buffGrassType = true;
			}
			if (!modPlayer.summonedFawnifer || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 49;
			player.meleeDamage *= 1.12f;
			player.rangedDamage *= 1.12f;
			player.magicDamage *= 1.1f;
			player.minionDamage *= 1.1f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}