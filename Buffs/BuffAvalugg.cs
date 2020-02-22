using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffAvalugg : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Avalugg!");
			Description.SetDefault("Avalugg was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Avalugg")] > 0) {
				modPlayer.summonedAvalugg = true;
			}
			if (!modPlayer.summonedAvalugg) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 18;
			}
			else
			{
				player.statDefense += 4;
			}
		}
	}
}