using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSandaconda : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Sandaconda!");
			Description.SetDefault("Sandaconda was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Sandaconda")] > 0) {
				modPlayer.summonedSandaconda = true;
			}
			if (!modPlayer.summonedSandaconda) {
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
				player.statDefense += 12;
			}
			else
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 107;
			player.meleeDamage *= 2.1f;
			player.rangedDamage *= 2.1f;
			player.magicDamage *= 1.6f;
			player.minionDamage *= 1.6f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}