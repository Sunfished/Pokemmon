using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffElectabuzz : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Electabuzz!");
			Description.SetDefault("Electabuzz was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Electabuzz")] > 0) {
				modPlayer.summonedElectabuzz = true;
			}
			if (!modPlayer.summonedElectabuzz) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 8;
			}
		}
	}
}