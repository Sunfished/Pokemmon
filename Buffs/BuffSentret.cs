using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSentret : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Sentret!");
			Description.SetDefault("+35 HP\n+1.1x Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+1.1x Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.1 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Sentret")] > 0) {
				modPlayer.summonedSentret = true;
			}
			if (!modPlayer.summonedSentret) {
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
			
			player.statLifeMax2 += 35;
			player.meleeDamage *= 1.1f;
			player.rangedDamage *= 1.1f;
			player.magicDamage *= 1.1f;
			player.minionDamage *= 1.1f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}