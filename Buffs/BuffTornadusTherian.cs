using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffTornadusTherian : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Tornadus!");
			Description.SetDefault("Tornadus was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("TornadusTherian")] > 0) {
				modPlayer.summonedTornadusTherian = true;
			}
			if (!modPlayer.summonedTornadusTherian) {
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
				player.statDefense += 9;
			}
		}
	}
}