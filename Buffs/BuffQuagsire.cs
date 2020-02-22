using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffQuagsire : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Quagsire!");
			Description.SetDefault("Quagsire was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Quagsire")] > 0) {
				modPlayer.summonedQuagsire = true;
			}
			if (!modPlayer.summonedQuagsire) {
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
				player.statDefense += 6;
			}
		}
	}
}