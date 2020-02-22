using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffObstagoon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Obstagoon!");
			Description.SetDefault("Obstagoon was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Obstagoon")] > 0) {
				modPlayer.summonedObstagoon = true;
			}
			if (!modPlayer.summonedObstagoon) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 10;
			}
			else
			{
				player.statDefense += 8;
			}
		}
	}
}