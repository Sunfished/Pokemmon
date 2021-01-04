using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSlowpokeGalar : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Slowpoke!");
			Description.SetDefault("Slowpoke was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("SlowpokeGalar")] > 0) {
				modPlayer.summonedSlowpokeGalar = true;
			}
			if (!modPlayer.summonedSlowpokeGalar) {
				player.DelBuff(buffIndex);
				buffIndex--;
				
			}
			else {
				player.buffTime[buffIndex] = 18000;
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
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 65;
			player.meleeDamage *= 1.6f;
			player.rangedDamage *= 1.6f;
			player.magicDamage *= 1.4f;
			player.minionDamage *= 1.4f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}