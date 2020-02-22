using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffAegislashBlade : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Aegislash!");
			Description.SetDefault("Aegislash was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("AegislashBlade")] > 0) {
				modPlayer.summonedAegislashBlade = true;
			}
			if (!modPlayer.summonedAegislashBlade) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 5;
			}
		}
	}
}