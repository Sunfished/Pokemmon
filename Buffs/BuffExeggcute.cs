using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffExeggcute : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Exeggcute!");
			Description.SetDefault("Exeggcute was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Exeggcute")] > 0) {
				modPlayer.summonedExeggcute = true;
			}
			if (!modPlayer.summonedExeggcute) {
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
				player.statDefense += 4;
			}
		}
	}
}