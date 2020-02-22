using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffPumpkabooSuperSize : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Pumpkaboo!");
			Description.SetDefault("Pumpkaboo was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("PumpkabooSuperSize")] > 0) {
				modPlayer.summonedPumpkabooSuperSize = true;
			}
			if (!modPlayer.summonedPumpkabooSuperSize) {
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
			else
			{
				player.statDefense += 5;
			}
		}
	}
}