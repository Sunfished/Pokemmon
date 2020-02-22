using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffScizorMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Scizor!");
			Description.SetDefault("Scizor was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("ScizorMega")] > 0) {
				modPlayer.summonedScizorMega = true;
			}
			if (!modPlayer.summonedScizorMega) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 14;
			}
			else
			{
				player.statDefense += 10;
			}
		}
	}
}