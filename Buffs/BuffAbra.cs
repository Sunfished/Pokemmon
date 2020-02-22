using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffAbra : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Abra!");
			Description.SetDefault("Abra was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Abra")] > 0) {
				modPlayer.summonedAbra = true;
			}
			if (!modPlayer.summonedAbra) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 1;
			}
			else
			{
				player.statDefense += 5;
			}
		}
	}
}