using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffDusclops : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Dusclops!");
			Description.SetDefault("Dusclops was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Dusclops")] > 0) {
				modPlayer.summonedDusclops = true;
			}
			if (!modPlayer.summonedDusclops) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 13;
			}
			else
			{
				player.statDefense += 13;
			}
		}
	}
}