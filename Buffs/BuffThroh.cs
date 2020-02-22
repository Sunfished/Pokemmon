using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffThroh : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Throh!");
			Description.SetDefault("Throh was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Throh")] > 0) {
				modPlayer.summonedThroh = true;
			}
			if (!modPlayer.summonedThroh) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 8;
			}
		}
	}
}