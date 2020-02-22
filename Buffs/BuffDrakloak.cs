using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffDrakloak : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Drakloak!");
			Description.SetDefault("Drakloak was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Drakloak")] > 0) {
				modPlayer.summonedDrakloak = true;
			}
			if (!modPlayer.summonedDrakloak) {
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
				player.statDefense += 5;
			}
		}
	}
}