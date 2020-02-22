using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffTyranitarMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Tyranitar!");
			Description.SetDefault("Tyranitar was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("TyranitarMega")] > 0) {
				modPlayer.summonedTyranitarMega = true;
			}
			if (!modPlayer.summonedTyranitarMega) {
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
				player.statDefense += 12;
			}
		}
	}
}