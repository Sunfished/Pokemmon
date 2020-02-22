using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffIllumise : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Illumise!");
			Description.SetDefault("Illumise was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Illumise")] > 0) {
				modPlayer.summonedIllumise = true;
			}
			if (!modPlayer.summonedIllumise) {
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
				player.statDefense += 8;
			}
		}
	}
}