using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffIndeedeeF : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Indeedee!");
			Description.SetDefault("Indeedee was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("IndeedeeF")] > 0) {
				modPlayer.summonedIndeedeeF = true;
			}
			if (!modPlayer.summonedIndeedeeF) {
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
				player.statDefense += 10;
			}
		}
	}
}