using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffLedian : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Ledian!");
			Description.SetDefault("+55 HP\n+1.1x Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+1.1x Magic/Summon Damage\n+11 Magic/Summon Defense\n+0.4 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Ledian")] > 0) {
				modPlayer.summonedLedian = true;
			}
			if (!modPlayer.summonedLedian) {
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
				player.statDefense += 11;
			}
			
			player.statLifeMax2 += 55;
			player.meleeDamage *= 1.1f;
			player.rangedDamage *= 1.1f;
			player.magicDamage *= 1.1f;
			player.minionDamage *= 1.1f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}