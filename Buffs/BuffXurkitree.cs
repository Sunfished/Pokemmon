using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffXurkitree : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Xurkitree!");
			Description.SetDefault("+83 HP\n+1.2x Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+1.5x Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.4 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Xurkitree")] > 0) {
				modPlayer.summonedXurkitree = true;
			}
			if (!modPlayer.summonedXurkitree) {
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
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 83;
			player.meleeDamage *= 1.2f;
			player.rangedDamage *= 1.2f;
			player.magicDamage *= 1.5f;
			player.minionDamage *= 1.5f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}