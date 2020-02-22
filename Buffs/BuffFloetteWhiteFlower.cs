using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffFloetteWhiteFlower : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Floette!");
			Description.SetDefault("Floette was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("FloetteWhiteFlower")] > 0) {
				modPlayer.summonedFloetteWhiteFlower = true;
			}
			if (!modPlayer.summonedFloetteWhiteFlower) {
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
				player.statDefense += 9;
			}
		}
	}
}