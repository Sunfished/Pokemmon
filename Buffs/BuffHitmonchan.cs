using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffHitmonchan : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Hitmonchan!");
			Description.SetDefault("Hitmonchan was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Hitmonchan")] > 0) {
				modPlayer.summonedHitmonchan = true;
			}
			if (!modPlayer.summonedHitmonchan) {
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
				player.statDefense += 11;
			}
		}
	}
}