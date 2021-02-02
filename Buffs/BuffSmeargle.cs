using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSmeargle : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Smeargle!");
			Description.SetDefault("+55 HP\n+1.0x Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+1.0x Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.4 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Smeargle")] > 0) {
				modPlayer.summonedSmeargle = true;
			}
			if (!modPlayer.summonedSmeargle) {
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
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 55;
			player.meleeDamage *= 1.0f;
			player.rangedDamage *= 1.0f;
			player.magicDamage *= 1.0f;
			player.minionDamage *= 1.0f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}