using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffCramorantGulping : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Cramorant!");
			Description.SetDefault("Cramorant was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("CramorantGulping")] > 0) {
				modPlayer.summonedCramorantGulping = true;
			}
			if (!modPlayer.summonedCramorantGulping) {
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