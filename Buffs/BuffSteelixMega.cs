using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSteelixMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Steelix!");
			Description.SetDefault("Steelix was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("SteelixMega")] > 0) {
				modPlayer.summonedSteelixMega = true;
			}
			if (!modPlayer.summonedSteelixMega) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 23;
			}
			else
			{
				player.statDefense += 9;
			}
		}
	}
}