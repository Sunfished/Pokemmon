using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffXerneasNeutral : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Xerneas!");
			Description.SetDefault("Xerneas was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("XerneasNeutral")] > 0) {
				modPlayer.summonedXerneasNeutral = true;
			}
			if (!modPlayer.summonedXerneasNeutral) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 9;
			}
		}
	}
}