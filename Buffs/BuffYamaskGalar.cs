using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffYamaskGalar : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Yamask!");
			Description.SetDefault("Yamask was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("YamaskGalar")] > 0) {
				modPlayer.summonedYamaskGalar = true;
			}
			if (!modPlayer.summonedYamaskGalar) {
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
			
			player.statLifeMax2 += 30;
			player.meleeDamage *= 1.3f;
			player.rangedDamage *= 1.3f;
			player.magicDamage *= 1.6f;
			player.maxRunSpeed += 0.1f;
		}

	}
}