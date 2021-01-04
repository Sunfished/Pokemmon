using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffBurmySandyCloak : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Burmy!");
			Description.SetDefault("Burmy was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("BurmySandyCloak")] > 0) {
				modPlayer.summonedBurmySandyCloak = true;
			}
			if (!modPlayer.summonedBurmySandyCloak) {
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
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 29;
			player.meleeDamage *= 1.3f;
			player.rangedDamage *= 1.3f;
			player.magicDamage *= 1.3f;
			player.minionDamage *= 1.3f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}