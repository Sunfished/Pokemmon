using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffGranbull : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Granbull!");
			Description.SetDefault("Granbull was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Granbull")] > 0) {
				modPlayer.summonedGranbull = true;
			}
			if (!modPlayer.summonedGranbull) {
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
				player.statDefense += 6;
			}
		}
	}
}