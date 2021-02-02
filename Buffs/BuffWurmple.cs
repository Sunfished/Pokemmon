using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffWurmple : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Wurmple!");
			Description.SetDefault("+45 HP\n+1.1x Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+1.0x Magic/Summon Damage\n+3 Magic/Summon Defense\n+0.1 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Wurmple")] > 0) {
				modPlayer.summonedWurmple = true;
			}
			if (!modPlayer.summonedWurmple) {
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
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 45;
			player.meleeDamage *= 1.1f;
			player.rangedDamage *= 1.1f;
			player.magicDamage *= 1.0f;
			player.minionDamage *= 1.0f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}