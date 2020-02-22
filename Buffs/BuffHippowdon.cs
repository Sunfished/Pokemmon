using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffHippowdon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Hippowdon!");
			Description.SetDefault("Hippowdon was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Hippowdon")] > 0) {
				modPlayer.summonedHippowdon = true;
			}
			if (!modPlayer.summonedHippowdon) {
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
				player.statDefense += 7;
			}
		}
	}
}