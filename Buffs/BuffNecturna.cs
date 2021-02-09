using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffNecturna : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Necturna!");
			Description.SetDefault("+64 HP\n+24% Melee/Ranged Damage\n+10 Melee/Ranged Defense\n+17% Magic/Summon Damage\n+12 Magic/Summon Defense\n+0.4 Speed\nGrass Type: Regens HP during daytime\nGhost Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Necturna")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedNecturna = true;
				modPlayer.buffGrassType = true;
				modPlayer.buffGhostType = true;
			}
			if (!modPlayer.summonedNecturna || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGrassType = false;
				modPlayer.buffGhostType = false;
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
				player.statDefense += 12;
			}
			
			player.statLifeMax2 += 64;
			player.meleeDamage *= 1.24f;
			player.rangedDamage *= 1.24f;
			player.magicDamage *= 1.17f;
			player.minionDamage *= 1.17f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}