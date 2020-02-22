using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffClefairy : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Clefairy!");
			Description.SetDefault("Clefairy was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Clefairy")] > 0) {
				modPlayer.summonedClefairy = true;
			}
			if (!modPlayer.summonedClefairy) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 6;
			}
		}
	}
}