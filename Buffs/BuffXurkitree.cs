using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffXurkitree : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Xurkitree!");
			Description.SetDefault("Xurkitree was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Xurkitree")] > 0) {
				modPlayer.summonedXurkitree = true;
			}
			if (!modPlayer.summonedXurkitree) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 7;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 89;
			player.meleeDamage *= 1.9f;
			player.rangedDamage *= 1.9f;
			player.magicDamage *= 2.7f;
			player.maxRunSpeed += 0.4f;
		}

	}
}