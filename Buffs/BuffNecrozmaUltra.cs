using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffNecrozmaUltra : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Necrozma!");
			Description.SetDefault("Necrozma was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("NecrozmaUltra")] > 0) {
				modPlayer.summonedNecrozmaUltra = true;
			}
			if (!modPlayer.summonedNecrozmaUltra) {
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
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 167;
			player.meleeDamage *= 2.7f;
			player.rangedDamage *= 2.7f;
			player.magicDamage *= 2.7f;
			player.minionDamage *= 2.7f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}