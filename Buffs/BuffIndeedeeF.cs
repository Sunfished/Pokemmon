using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffIndeedeeF : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Indeedee!");
			Description.SetDefault("+70 HP\n+1.1x Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+1.3x Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.4 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("IndeedeeF")] > 0) {
				modPlayer.summonedIndeedeeF = true;
			}
			if (!modPlayer.summonedIndeedeeF) {
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
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 70;
			player.meleeDamage *= 1.1f;
			player.rangedDamage *= 1.1f;
			player.magicDamage *= 1.3f;
			player.minionDamage *= 1.3f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}