using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffOrbeetleGigantamax : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Orbeetle!");
			Description.SetDefault("Orbeetle was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("OrbeetleGigantamax")] > 0) {
				modPlayer.summonedOrbeetleGigantamax = true;
			}
			if (!modPlayer.summonedOrbeetleGigantamax) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 11;
			}
			else
			{
				player.statDefense += 12;
			}
		}
	}
}