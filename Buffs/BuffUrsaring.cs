using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffUrsaring : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Ursaring!");
			Description.SetDefault("Ursaring was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Ursaring")] > 0) {
				modPlayer.summonedUrsaring = true;
			}
			if (!modPlayer.summonedUrsaring) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 7;
			}
		}
	}
}