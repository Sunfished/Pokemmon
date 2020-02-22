using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffExcadrill : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Excadrill!");
			Description.SetDefault("Excadrill was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Excadrill")] > 0) {
				modPlayer.summonedExcadrill = true;
			}
			if (!modPlayer.summonedExcadrill) {
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