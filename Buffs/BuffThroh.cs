using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffThroh : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Throh!");
			Description.SetDefault("Throh was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Throh")] > 0) {
				modPlayer.summonedThroh = true;
			}
			if (!modPlayer.summonedThroh) {
				player.DelBuff(buffIndex);
				buffIndex--;
				
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			var isMelee = true;
			if(player.magicDamage > player.meleeDamage || player.magicDamage > player.rangedDamage ||
			player.minionDamage > player.meleeDamage || player.minionDamage > player.rangedDamage)
				isMelee = false;
			if (isMelee)
			{
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 100;
			player.meleeDamage *= 2.0f;
			player.rangedDamage *= 2.0f;
			player.magicDamage *= 1.3f;
			player.minionDamage *= 1.3f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}