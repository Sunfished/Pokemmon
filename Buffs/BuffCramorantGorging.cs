using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffCramorantGorging : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Cramorant!");
			Description.SetDefault("Cramorant was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("CramorantGorging")] > 0) {
				modPlayer.summonedCramorantGorging = true;
			}
			if (!modPlayer.summonedCramorantGorging) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 9;
			}
		}
	}
}