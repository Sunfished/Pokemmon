using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffUmbreon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Umbreon!");
			Description.SetDefault("Umbreon was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Umbreon")] > 0) {
				modPlayer.summonedUmbreon = true;
			}
			if (!modPlayer.summonedUmbreon) {
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
				player.statDefense += 13;
			}
		}
	}
}