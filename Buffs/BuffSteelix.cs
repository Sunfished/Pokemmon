using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSteelix : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Steelix!");
			Description.SetDefault("Steelix was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Steelix")] > 0) {
				modPlayer.summonedSteelix = true;
			}
			if (!modPlayer.summonedSteelix) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 20;
			}
			else
			{
				player.statDefense += 6;
			}
		}
	}
}