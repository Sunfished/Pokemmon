using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffMudkip : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Mudkip!");
			Description.SetDefault("Mudkip was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Mudkip")] > 0) {
				modPlayer.summonedMudkip = true;
			}
			if (!modPlayer.summonedMudkip) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
		public override void PostUpdate(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
		
			//Calc Buffs
			player.meleeDamage *= 1.7f;
			player.rangedDamage *= 1.7f;
			player.magicDamage *= 1.5f;
			player.maxRunSpeed += 0.2f
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 5;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 5;
			}
		}
	}
}