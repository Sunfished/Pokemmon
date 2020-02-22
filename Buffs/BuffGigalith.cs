using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffGigalith : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Gigalith!");
			Description.SetDefault("Gigalith was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Gigalith")] > 0) {
				modPlayer.summonedGigalith = true;
			}
			if (!modPlayer.summonedGigalith) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 13;
			}
			else
			{
				player.statDefense += 8;
			}
		}
	}
}