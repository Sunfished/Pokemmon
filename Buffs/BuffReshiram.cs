using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffReshiram : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Reshiram!");
			Description.SetDefault("+100 HP\n+1.4x Melee/Ranged Damage\n+10 Melee/Ranged Defense\n+1.5x Magic/Summon Damage\n+12 Magic/Summon Defense\n+0.5 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Reshiram")] > 0) {
				modPlayer.summonedReshiram = true;
			}
			if (!modPlayer.summonedReshiram) {
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
				player.statDefense += 12;
			}
			
			player.statLifeMax2 += 100;
			player.meleeDamage *= 1.4f;
			player.rangedDamage *= 1.4f;
			player.magicDamage *= 1.5f;
			player.minionDamage *= 1.5f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}