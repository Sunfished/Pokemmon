using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffExcadrill : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Excadrill!");
			Description.SetDefault("Excadrill was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Excadrill")] > 0) {
				modPlayer.summonedExcadrill = true;
			}
			if (!modPlayer.summonedExcadrill) {
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
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 135;
			player.meleeDamage *= 2.4f;
			player.rangedDamage *= 2.4f;
			player.magicDamage *= 1.5f;
			player.maxRunSpeed += 0.4f;
		}

	}
}