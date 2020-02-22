using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffMimikyuBusted : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Mimikyu!");
			Description.SetDefault("Mimikyu was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("MimikyuBusted")] > 0) {
				modPlayer.summonedMimikyuBusted = true;
			}
			if (!modPlayer.summonedMimikyuBusted) {
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
				player.statDefense += 10;
			}
		}
	}
}