using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffZangoose : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Zangoose!");
			Description.SetDefault("Zangoose was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Zangoose")] > 0) {
				modPlayer.summonedZangoose = true;
			}
			if (!modPlayer.summonedZangoose) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 6;
			}
		}
	}
}