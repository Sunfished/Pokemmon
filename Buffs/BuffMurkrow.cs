using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffMurkrow : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Murkrow!");
			Description.SetDefault("Murkrow was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Murkrow")] > 0) {
				modPlayer.summonedMurkrow = true;
			}
			if (!modPlayer.summonedMurkrow) {
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