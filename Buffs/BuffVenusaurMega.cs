using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffVenusaurMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Venusaur!");
			Description.SetDefault("Venusaur was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("VenusaurMega")] > 0) {
				modPlayer.summonedVenusaurMega = true;
			}
			if (!modPlayer.summonedVenusaurMega) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 12;
			}
			else
			{
				player.statDefense += 12;
			}
		}
	}
}