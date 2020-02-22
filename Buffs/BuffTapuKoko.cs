using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffTapuKoko : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Tapu Koko!");
			Description.SetDefault("Tapu Koko was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("TapuKoko")] > 0) {
				modPlayer.summonedTapuKoko = true;
			}
			if (!modPlayer.summonedTapuKoko) {
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
				player.statDefense += 7;
			}
		}
	}
}