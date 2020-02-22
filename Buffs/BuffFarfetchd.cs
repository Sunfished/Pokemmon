using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffFarfetchd : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Farfetch'd!");
			Description.SetDefault("Farfetch'd was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Farfetchd")] > 0) {
				modPlayer.summonedFarfetchd = true;
			}
			if (!modPlayer.summonedFarfetchd) {
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
				player.statDefense += 6;
			}
		}
	}
}