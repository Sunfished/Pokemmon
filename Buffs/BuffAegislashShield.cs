using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffAegislashShield : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Aegislash!");
			Description.SetDefault("Aegislash was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("AegislashShield")] > 0) {
				modPlayer.summonedAegislashShield = true;
			}
			if (!modPlayer.summonedAegislashShield) {
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
				player.statDefense += 14;
			}
		}
	}
}