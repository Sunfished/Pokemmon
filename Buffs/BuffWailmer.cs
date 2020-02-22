using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffWailmer : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Wailmer!");
			Description.SetDefault("Wailmer was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Wailmer")] > 0) {
				modPlayer.summonedWailmer = true;
			}
			if (!modPlayer.summonedWailmer) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 3;
			}
		}
	}
}