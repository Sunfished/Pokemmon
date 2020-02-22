using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffTorkoal : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Torkoal!");
			Description.SetDefault("Torkoal was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Torkoal")] > 0) {
				modPlayer.summonedTorkoal = true;
			}
			if (!modPlayer.summonedTorkoal) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 14;
			}
			else
			{
				player.statDefense += 7;
			}
		}
	}
}