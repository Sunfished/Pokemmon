using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffComfey : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Comfey!");
			Description.SetDefault("Comfey was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Comfey")] > 0) {
				modPlayer.summonedComfey = true;
			}
			if (!modPlayer.summonedComfey) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 9;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 11;
			}
			
			player.statLifeMax2 += 52;
			player.meleeDamage *= 1.5f;
			player.rangedDamage *= 1.5f;
			player.magicDamage *= 1.8f;
			player.maxRunSpeed += 0.5f;
		}

	}
}