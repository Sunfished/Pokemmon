using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffLombre : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Lombre!");
			Description.SetDefault("Lombre was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Lombre")] > 0) {
				modPlayer.summonedLombre = true;
			}
			if (!modPlayer.summonedLombre) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 7;
			}
		}
	}
}