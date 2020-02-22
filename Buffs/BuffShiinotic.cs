using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffShiinotic : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Shiinotic!");
			Description.SetDefault("Shiinotic was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Shiinotic")] > 0) {
				modPlayer.summonedShiinotic = true;
			}
			if (!modPlayer.summonedShiinotic) {
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
				player.statDefense += 10;
			}
		}
	}
}