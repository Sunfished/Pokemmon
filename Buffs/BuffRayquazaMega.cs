using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffRayquazaMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Rayquaza!");
			Description.SetDefault("Rayquaza was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("RayquazaMega")] > 0) {
				modPlayer.summonedRayquazaMega = true;
			}
			if (!modPlayer.summonedRayquazaMega) {
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
			
			player.statLifeMax2 += 180;
			player.meleeDamage *= 2.8f;
			player.rangedDamage *= 2.8f;
			player.magicDamage *= 2.8f;
			player.maxRunSpeed += 0.6f;
		}

	}
}