using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffStakataka : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Stakataka!");
			Description.SetDefault("Stakataka was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Stakataka")] > 0) {
				modPlayer.summonedStakataka = true;
			}
			if (!modPlayer.summonedStakataka) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 21;
			}
			else
			{
				player.statDefense += 10;
			}
		}
	}
}