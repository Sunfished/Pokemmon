using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSharpedoMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Sharpedo!");
			Description.SetDefault("Sharpedo was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("SharpedoMega")] > 0) {
				modPlayer.summonedSharpedoMega = true;
			}
			if (!modPlayer.summonedSharpedoMega) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
		public override void PostUpdate(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
		
			//Calc Buffs
			player.meleeDamage *= 2.4f;
			player.rangedDamage *= 2.4f;
			player.magicDamage *= 2.1f;
			player.maxRunSpeed += 0.5f
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 7;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 6;
			}
		}
	}
}