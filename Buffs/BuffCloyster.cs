using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffCloyster : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Cloyster!");
			Description.SetDefault("Cloyster was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Cloyster")] > 0) {
				modPlayer.summonedCloyster = true;
			}
			if (!modPlayer.summonedCloyster) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 18;
			}
			else
			{
				player.statDefense += 4;
			}
		}
	}
}