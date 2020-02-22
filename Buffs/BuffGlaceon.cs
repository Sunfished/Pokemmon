using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffGlaceon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Glaceon!");
			Description.SetDefault("Glaceon was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Glaceon")] > 0) {
				modPlayer.summonedGlaceon = true;
			}
			if (!modPlayer.summonedGlaceon) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 11;
			}
			else
			{
				player.statDefense += 9;
			}
		}
	}
}