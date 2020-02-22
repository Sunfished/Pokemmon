using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffBuzzwole : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Buzzwole!");
			Description.SetDefault("Buzzwole was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Buzzwole")] > 0) {
				modPlayer.summonedBuzzwole = true;
			}
			if (!modPlayer.summonedBuzzwole) {
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
				player.statDefense += 5;
			}
		}
	}
}