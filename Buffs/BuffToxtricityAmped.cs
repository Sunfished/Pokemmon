using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffToxtricityAmped : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Toxtricity!");
			Description.SetDefault("Toxtricity was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("ToxtricityAmped")] > 0) {
				modPlayer.summonedToxtricityAmped = true;
			}
			if (!modPlayer.summonedToxtricityAmped) {
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