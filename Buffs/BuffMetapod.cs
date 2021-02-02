using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffMetapod : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Metapod!");
			Description.SetDefault("+50 HP\n+1.0x Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+1.0x Magic/Summon Damage\n+2 Magic/Summon Defense\n+0.1 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Metapod")] > 0) {
				modPlayer.summonedMetapod = true;
			}
			if (!modPlayer.summonedMetapod) {
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 2;
			}
			
			player.statLifeMax2 += 50;
			player.meleeDamage *= 1.0f;
			player.rangedDamage *= 1.0f;
			player.magicDamage *= 1.0f;
			player.minionDamage *= 1.0f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}