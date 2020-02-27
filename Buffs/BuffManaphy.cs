using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffManaphy : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Manaphy!");
			Description.SetDefault("Manaphy was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Manaphy")] > 0) {
				modPlayer.summonedManaphy = true;
			}
			if (!modPlayer.summonedManaphy) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 10;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 100;
			player.meleeDamage *= 2.0f;
			player.rangedDamage *= 2.0f;
			player.magicDamage *= 2.0f;
			player.maxRunSpeed += 0.5f;
		}

	}
}