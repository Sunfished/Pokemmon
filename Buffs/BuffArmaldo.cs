using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffArmaldo : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Armaldo!");
			Description.SetDefault("Armaldo was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Armaldo")] > 0) {
				modPlayer.summonedArmaldo = true;
			}
			if (!modPlayer.summonedArmaldo) {
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