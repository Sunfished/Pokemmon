using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffGardevoirMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Gardevoir!");
			Description.SetDefault("Gardevoir was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("GardevoirMega")] > 0) {
				modPlayer.summonedGardevoirMega = true;
			}
			if (!modPlayer.summonedGardevoirMega) {
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
				player.statDefense += 13;
			}
		}
	}
}