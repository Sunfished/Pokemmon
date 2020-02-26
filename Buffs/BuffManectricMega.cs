using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffManectricMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Manectric!");
			Description.SetDefault("Manectric was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("ManectricMega")] > 0) {
				modPlayer.summonedManectricMega = true;
			}
			if (!modPlayer.summonedManectricMega) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
		public override void PostUpdate(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
		
			//Calc Buffs
			player.meleeDamage *= 1.8f;
			player.rangedDamage *= 1.8f;
			player.magicDamage *= 2.4f;
			player.maxRunSpeed += 0.7f
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 8;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 8;
			}
		}
	}
}