using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffPonytaGalar : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Ponyta!");
			Description.SetDefault("Ponyta was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("PonytaGalar")] > 0) {
				modPlayer.summonedPonytaGalar = true;
			}
			if (!modPlayer.summonedPonytaGalar) {
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 85;
			player.meleeDamage *= 1.9f;
			player.rangedDamage *= 1.9f;
			player.magicDamage *= 1.6f;
			player.minionDamage *= 1.6f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}