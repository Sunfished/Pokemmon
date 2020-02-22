using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffVolcanion : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Volcanion!");
			Description.SetDefault("Volcanion was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Volcanion")] > 0) {
				modPlayer.summonedVolcanion = true;
			}
			if (!modPlayer.summonedVolcanion) {
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
				player.statDefense += 9;
			}
		}
	}
}