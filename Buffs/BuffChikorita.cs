using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffChikorita : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Chikorita!");
			Description.SetDefault("Chikorita was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Chikorita")] > 0) {
				modPlayer.summonedChikorita = true;
			}
			if (!modPlayer.summonedChikorita) {
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