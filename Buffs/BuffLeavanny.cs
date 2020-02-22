using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffLeavanny : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Leavanny!");
			Description.SetDefault("Leavanny was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Leavanny")] > 0) {
				modPlayer.summonedLeavanny = true;
			}
			if (!modPlayer.summonedLeavanny) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 8;
			}
		}
	}
}