using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffDiancieMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Diancie!");
			Description.SetDefault("Diancie was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("DiancieMega")] > 0) {
				modPlayer.summonedDiancieMega = true;
			}
			if (!modPlayer.summonedDiancieMega) {
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
				player.statDefense += 11;
			}
			else
			{
				player.statDefense += 11;
			}
			
			player.statLifeMax2 += 160;
			player.meleeDamage *= 2.6f;
			player.rangedDamage *= 2.6f;
			player.magicDamage *= 2.6f;
			player.minionDamage *= 2.6f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}