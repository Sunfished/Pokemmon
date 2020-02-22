using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffHoothoot : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Hoothoot!");
			Description.SetDefault("Hoothoot was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Hoothoot")] > 0) {
				modPlayer.summonedHoothoot = true;
			}
			if (!modPlayer.summonedHoothoot) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 5;
			}
		}
	}
}