using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffOricorioBaileStyle : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Oricorio!");
			Description.SetDefault("Oricorio was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("OricorioBaileStyle")] > 0) {
				modPlayer.summonedOricorioBaileStyle = true;
			}
			if (!modPlayer.summonedOricorioBaileStyle) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 7;
			}
		}
	}
}