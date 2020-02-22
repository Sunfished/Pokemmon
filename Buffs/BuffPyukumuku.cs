using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffPyukumuku : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Pyukumuku!");
			Description.SetDefault("Pyukumuku was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Pyukumuku")] > 0) {
				modPlayer.summonedPyukumuku = true;
			}
			if (!modPlayer.summonedPyukumuku) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 13;
			}
			else
			{
				player.statDefense += 13;
			}
		}
	}
}