using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffProbopass : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Probopass!");
			Description.SetDefault("Probopass was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Probopass")] > 0) {
				modPlayer.summonedProbopass = true;
			}
			if (!modPlayer.summonedProbopass) {
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
				player.statDefense += 15;
			}
		}
	}
}