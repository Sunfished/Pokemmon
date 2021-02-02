using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffKommoo : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Kommo-o!");
			Description.SetDefault("+75 HP\n+1.3x Melee/Ranged Damage\n+12 Melee/Ranged Defense\n+1.3x Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.4 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Kommoo")] > 0) {
				modPlayer.summonedKommoo = true;
			}
			if (!modPlayer.summonedKommoo) {
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
				player.statDefense += 12;
			}
			else
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 75;
			player.meleeDamage *= 1.3f;
			player.rangedDamage *= 1.3f;
			player.magicDamage *= 1.3f;
			player.minionDamage *= 1.3f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}