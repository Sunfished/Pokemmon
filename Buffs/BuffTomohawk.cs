using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffTomohawk : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Tomohawk!");
			Description.SetDefault("Tomohawk was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Tomohawk")] > 0) {
				modPlayer.summonedTomohawk = true;
			}
			if (!modPlayer.summonedTomohawk) {
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
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 60;
			player.meleeDamage *= 1.6f;
			player.rangedDamage *= 1.6f;
			player.magicDamage *= 2.1f;
			player.minionDamage *= 2.1f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}