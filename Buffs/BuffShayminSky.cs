using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffShayminSky : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Shaymin!");
			Description.SetDefault("Shaymin was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("ShayminSky")] > 0) {
				modPlayer.summonedShayminSky = true;
			}
			if (!modPlayer.summonedShayminSky) {
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