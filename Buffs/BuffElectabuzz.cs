using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffElectabuzz : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Electabuzz!");
			Description.SetDefault("+65 HP\n+1.2x Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+1.3x Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.5 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Electabuzz")] > 0) {
				modPlayer.summonedElectabuzz = true;
			}
			if (!modPlayer.summonedElectabuzz) {
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
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 65;
			player.meleeDamage *= 1.2f;
			player.rangedDamage *= 1.2f;
			player.magicDamage *= 1.3f;
			player.minionDamage *= 1.3f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}