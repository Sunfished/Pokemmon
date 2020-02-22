using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffShinx : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Shinx!");
			Description.SetDefault("Shinx was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Shinx")] > 0) {
				modPlayer.summonedShinx = true;
			}
			if (!modPlayer.summonedShinx) {
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
				player.statDefense += 3;
			}
		}
	}
}