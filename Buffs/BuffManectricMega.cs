using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffManectricMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Manectric!");
			Description.SetDefault("+70 HP\n+1.2x Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+1.4x Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.7 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("ManectricMega")] > 0) {
				modPlayer.summonedManectricMega = true;
			}
			if (!modPlayer.summonedManectricMega) {
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
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 70;
			player.meleeDamage *= 1.2f;
			player.rangedDamage *= 1.2f;
			player.magicDamage *= 1.4f;
			player.minionDamage *= 1.4f;
			player.maxRunSpeed += 0.7f;
			
			//modPlayer.numSpawned++;
		}
	}
}