using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffOnix : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Onix!");
			Description.SetDefault("Onix was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Onix")] > 0) {
				modPlayer.summonedOnix = true;
			}
			if (!modPlayer.summonedOnix) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 16;
			}
			else
			{
				player.statDefense += 4;
			}
		}
	}
}