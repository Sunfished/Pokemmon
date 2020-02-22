using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffHappiny : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Happiny!");
			Description.SetDefault("Happiny was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Happiny")] > 0) {
				modPlayer.summonedHappiny = true;
			}
			if (!modPlayer.summonedHappiny) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 0;
			}
			else
			{
				player.statDefense += 6;
			}
		}
	}
}