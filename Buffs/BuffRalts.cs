using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffRalts : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Ralts!");
			Description.SetDefault("Ralts was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Ralts")] > 0) {
				modPlayer.summonedRalts = true;
			}
			if (!modPlayer.summonedRalts) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 2;
			}
			else
			{
				player.statDefense += 3;
			}
		}
	}
}