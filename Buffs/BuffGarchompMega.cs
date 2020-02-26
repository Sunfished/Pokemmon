using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffGarchompMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Garchomp!");
			Description.SetDefault("Garchomp was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("GarchompMega")] > 0) {
				modPlayer.summonedGarchompMega = true;
			}
			if (!modPlayer.summonedGarchompMega) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
		public override void PostUpdate(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
		
			//Calc Buffs
			player.meleeDamage *= 2.7f;
			player.rangedDamage *= 2.7f;
			player.magicDamage *= 2.2f;
			player.maxRunSpeed += 0.5f
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 11;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 9;
			}
		}
	}
}