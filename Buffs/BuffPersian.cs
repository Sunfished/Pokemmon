using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffPersian : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Persian!");
			Description.SetDefault("Persian was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Persian")] > 0) {
				modPlayer.summonedPersian = true;
			}
			if (!modPlayer.summonedPersian) {
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
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 70;
			player.meleeDamage *= 1.7f;
			player.rangedDamage *= 1.7f;
			player.magicDamage *= 1.6f;
			player.minionDamage *= 1.6f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}