using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffRayquaza : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Rayquaza!");
			Description.SetDefault("+105 HP\n+1.5x Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+1.5x Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.5 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Rayquaza")] > 0) {
				modPlayer.summonedRayquaza = true;
			}
			if (!modPlayer.summonedRayquaza) {
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
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 105;
			player.meleeDamage *= 1.5f;
			player.rangedDamage *= 1.5f;
			player.magicDamage *= 1.5f;
			player.minionDamage *= 1.5f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}