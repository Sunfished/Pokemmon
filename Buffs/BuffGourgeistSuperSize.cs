using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffGourgeistSuperSize : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Gourgeist!");
			Description.SetDefault("+85 HP\n+1.3x Melee/Ranged Damage\n+12 Melee/Ranged Defense\n+1.1x Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.3 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("GourgeistSuperSize")] > 0) {
				modPlayer.summonedGourgeistSuperSize = true;
			}
			if (!modPlayer.summonedGourgeistSuperSize) {
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
			
			player.statLifeMax2 += 85;
			player.meleeDamage *= 1.3f;
			player.rangedDamage *= 1.3f;
			player.magicDamage *= 1.1f;
			player.minionDamage *= 1.1f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}