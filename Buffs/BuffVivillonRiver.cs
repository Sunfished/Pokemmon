using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffVivillonRiver : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Vivillon!");
			Description.SetDefault("Vivillon was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("VivillonRiver")] > 0) {
				modPlayer.summonedVivillonRiver = true;
			}
			if (!modPlayer.summonedVivillonRiver) {
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