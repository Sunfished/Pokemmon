using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffNickit : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Nickit!");
			Description.SetDefault("Nickit was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Nickit")] > 0) {
				modPlayer.summonedNickit = true;
			}
			if (!modPlayer.summonedNickit) {
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
				player.statDefense += 5;
			}
		}
	}
}