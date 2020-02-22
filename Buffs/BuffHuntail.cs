using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffHuntail : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Huntail!");
			Description.SetDefault("Huntail was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Huntail")] > 0) {
				modPlayer.summonedHuntail = true;
			}
			if (!modPlayer.summonedHuntail) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 10;
			}
			else
			{
				player.statDefense += 7;
			}
		}
	}
}