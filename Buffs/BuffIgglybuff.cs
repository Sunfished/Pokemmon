using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffIgglybuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Igglybuff!");
			Description.SetDefault("Igglybuff was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Igglybuff")] > 0) {
				modPlayer.summonedIgglybuff = true;
			}
			if (!modPlayer.summonedIgglybuff) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 1;
			}
			else
			{
				player.statDefense += 2;
			}
		}
	}
}