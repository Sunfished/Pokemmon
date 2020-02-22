using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffInfernape : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Infernape!");
			Description.SetDefault("Infernape was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Infernape")] > 0) {
				modPlayer.summonedInfernape = true;
			}
			if (!modPlayer.summonedInfernape) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 7;
			}
		}
	}
}