using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSlowbroMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Slowbro!");
			Description.SetDefault("Slowbro was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("SlowbroMega")] > 0) {
				modPlayer.summonedSlowbroMega = true;
			}
			if (!modPlayer.summonedSlowbroMega) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 18;
			}
			else
			{
				player.statDefense += 8;
			}
		}
	}
}