using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffJirachi : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Jirachi!");
			Description.SetDefault("Jirachi was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Jirachi")] > 0) {
				modPlayer.summonedJirachi = true;
			}
			if (!modPlayer.summonedJirachi) {
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
				player.statDefense += 10;
			}
		}
	}
}