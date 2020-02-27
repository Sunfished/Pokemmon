using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffGroudonPrimal : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Groudon!");
			Description.SetDefault("Groudon was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("GroudonPrimal")] > 0) {
				modPlayer.summonedGroudonPrimal = true;
			}
			if (!modPlayer.summonedGroudonPrimal) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 16;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 180;
			player.meleeDamage *= 2.8f;
			player.rangedDamage *= 2.8f;
			player.magicDamage *= 2.5f;
			player.maxRunSpeed += 0.5f;
		}

	}
}