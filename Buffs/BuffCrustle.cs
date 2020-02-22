using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffCrustle : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Crustle!");
			Description.SetDefault("Crustle was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Crustle")] > 0) {
				modPlayer.summonedCrustle = true;
			}
			if (!modPlayer.summonedCrustle) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 12;
			}
			else
			{
				player.statDefense += 7;
			}
		}
	}
}