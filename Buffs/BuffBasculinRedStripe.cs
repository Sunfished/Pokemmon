using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffBasculinRedStripe : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Basculin!");
			Description.SetDefault("Basculin was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("BasculinRedStripe")] > 0) {
				modPlayer.summonedBasculinRedStripe = true;
			}
			if (!modPlayer.summonedBasculinRedStripe) {
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
				player.statDefense += 5;
			}
		}
	}
}