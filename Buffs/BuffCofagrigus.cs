using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffCofagrigus : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Cofagrigus!");
			Description.SetDefault("Cofagrigus was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Cofagrigus")] > 0) {
				modPlayer.summonedCofagrigus = true;
			}
			if (!modPlayer.summonedCofagrigus) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 14;
			}
			else
			{
				player.statDefense += 10;
			}
		}
	}
}