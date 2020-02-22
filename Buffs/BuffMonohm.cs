using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffMonohm : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Monohm!");
			Description.SetDefault("Monohm was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Monohm")] > 0) {
				modPlayer.summonedMonohm = true;
			}
			if (!modPlayer.summonedMonohm) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 0;
			}
			else
			{
				player.statDefense += 0;
			}
		}
	}
}