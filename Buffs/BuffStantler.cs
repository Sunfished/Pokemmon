using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffStantler : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Stantler!");
			Description.SetDefault("+73 HP\n+1.3x Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+1.2x Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.4 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Stantler")] > 0) {
				modPlayer.summonedStantler = true;
			}
			if (!modPlayer.summonedStantler) {
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
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 73;
			player.meleeDamage *= 1.3f;
			player.rangedDamage *= 1.3f;
			player.magicDamage *= 1.2f;
			player.minionDamage *= 1.2f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}