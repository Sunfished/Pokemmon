using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffDoublade : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Doublade!");
			Description.SetDefault("Doublade was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Doublade")] > 0) {
				modPlayer.summonedDoublade = true;
			}
			if (!modPlayer.summonedDoublade) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 15;
			}
			else
			{
				player.statDefense += 4;
			}
		}
	}
}