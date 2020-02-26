using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffAlakazamMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Alakazam!");
			Description.SetDefault("Alakazam was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("AlakazamMega")] > 0) {
				modPlayer.summonedAlakazamMega = true;
			}
			if (!modPlayer.summonedAlakazamMega) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
		public override void PostUpdate(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
		
			//Calc Buffs
			player.meleeDamage *= 1.5f;
			player.rangedDamage *= 1.5f;
			player.magicDamage *= 2.8f;
			player.maxRunSpeed += 0.8f
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 6;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 10;
			}
		}
	}
}