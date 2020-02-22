using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSmoochum : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Smoochum!");
			Description.SetDefault("Smoochum was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Smoochum")] > 0) {
				modPlayer.summonedSmoochum = true;
			}
			if (!modPlayer.summonedSmoochum) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 1;
			}
			else
			{
				player.statDefense += 6;
			}
		}
	}
}