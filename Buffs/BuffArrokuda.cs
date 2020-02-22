using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffArrokuda : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Arrokuda!");
			Description.SetDefault("Arrokuda was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Arrokuda")] > 0) {
				modPlayer.summonedArrokuda = true;
			}
			if (!modPlayer.summonedArrokuda) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 3;
			}
		}
	}
}