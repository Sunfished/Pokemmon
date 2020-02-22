using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffToxel : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Toxel!");
			Description.SetDefault("Toxel was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Toxel")] > 0) {
				modPlayer.summonedToxel = true;
			}
			if (!modPlayer.summonedToxel) {
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