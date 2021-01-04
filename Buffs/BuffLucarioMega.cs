using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffLucarioMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Lucario!");
			Description.SetDefault("Lucario was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("LucarioMega")] > 0) {
				modPlayer.summonedLucarioMega = true;
			}
			if (!modPlayer.summonedLucarioMega) {
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
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 145;
			player.meleeDamage *= 2.5f;
			player.rangedDamage *= 2.5f;
			player.magicDamage *= 2.4f;
			player.minionDamage *= 2.4f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}