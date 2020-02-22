using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffForretress : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Forretress!");
			Description.SetDefault("Forretress was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Forretress")] > 0) {
				modPlayer.summonedForretress = true;
			}
			if (!modPlayer.summonedForretress) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 14;
			}
			else
			{
				player.statDefense += 6;
			}
		}
	}
}