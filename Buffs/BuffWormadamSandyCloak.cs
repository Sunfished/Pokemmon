using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffWormadamSandyCloak : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Wormadam!");
			Description.SetDefault("Wormadam was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("WormadamSandyCloak")] > 0) {
				modPlayer.summonedWormadamSandyCloak = true;
			}
			if (!modPlayer.summonedWormadamSandyCloak) {
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