using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffRegice : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Regice!");
			Description.SetDefault("Regice was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Regice")] > 0) {
				modPlayer.summonedRegice = true;
			}
			if (!modPlayer.summonedRegice) {
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
				player.statDefense += 10;
			}
			else
			{
				player.statDefense += 20;
			}
			
			player.statLifeMax2 += 50;
			player.meleeDamage *= 1.5f;
			player.rangedDamage *= 1.5f;
			player.magicDamage *= 2.0f;
			player.minionDamage *= 2.0f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}