using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffWeezingGalar : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Weezing!");
			Description.SetDefault("Weezing was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("WeezingGalar")] > 0) {
				modPlayer.summonedWeezingGalar = true;
			}
			if (!modPlayer.summonedWeezingGalar) {
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