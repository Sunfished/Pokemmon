using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffMetagrossMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Metagross!");
			Description.SetDefault("Metagross was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("MetagrossMega")] > 0) {
				modPlayer.summonedMetagrossMega = true;
			}
			if (!modPlayer.summonedMetagrossMega) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 15;
			}
			else
			{
				player.statDefense += 11;
			}
		}
	}
}