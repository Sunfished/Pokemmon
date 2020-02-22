using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffInteleon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Inteleon!");
			Description.SetDefault("Inteleon was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Inteleon")] > 0) {
				modPlayer.summonedInteleon = true;
			}
			if (!modPlayer.summonedInteleon) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 6;
			}
		}
	}
}