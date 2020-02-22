using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffOctillery : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Octillery!");
			Description.SetDefault("Octillery was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Octillery")] > 0) {
				modPlayer.summonedOctillery = true;
			}
			if (!modPlayer.summonedOctillery) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 7;
			}
		}
	}
}