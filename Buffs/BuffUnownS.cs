using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffUnownS : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Unown!");
			Description.SetDefault("Unown was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("UnownS")] > 0) {
				modPlayer.summonedUnownS = true;
			}
			if (!modPlayer.summonedUnownS) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 4;
			}
		}
	}
}