using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffHawlucha : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Hawlucha!");
			Description.SetDefault("+78 HP\n+1.3x Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+1.2x Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.6 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Hawlucha")] > 0) {
				modPlayer.summonedHawlucha = true;
			}
			if (!modPlayer.summonedHawlucha) {
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
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 78;
			player.meleeDamage *= 1.3f;
			player.rangedDamage *= 1.3f;
			player.magicDamage *= 1.2f;
			player.minionDamage *= 1.2f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}