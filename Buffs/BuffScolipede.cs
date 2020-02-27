using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffScolipede : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Scolipede!");
			Description.SetDefault("Scolipede was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Scolipede")] > 0) {
				modPlayer.summonedScolipede = true;
			}
			if (!modPlayer.summonedScolipede) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 8;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 100;
			player.meleeDamage *= 2.0f;
			player.rangedDamage *= 2.0f;
			player.magicDamage *= 1.6f;
			player.maxRunSpeed += 0.6f;
		}

	}
}