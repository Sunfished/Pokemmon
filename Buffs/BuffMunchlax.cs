using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffMunchlax : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Munchlax!");
			Description.SetDefault("Munchlax was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Munchlax")] > 0) {
				modPlayer.summonedMunchlax = true;
			}
			if (!modPlayer.summonedMunchlax) {
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
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 85;
			player.meleeDamage *= 1.9f;
			player.rangedDamage *= 1.9f;
			player.magicDamage *= 1.4f;
			player.minionDamage *= 1.4f;
			player.maxRunSpeed += 0.0f;
			
			//modPlayer.numSpawned++;
		}
	}
}