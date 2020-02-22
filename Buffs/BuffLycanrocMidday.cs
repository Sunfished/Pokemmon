using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffLycanrocMidday : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Lycanroc!");
			Description.SetDefault("Lycanroc was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("LycanrocMidday")] > 0) {
				modPlayer.summonedLycanrocMidday = true;
			}
			if (!modPlayer.summonedLycanrocMidday) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 6;
			}
		}
	}
}