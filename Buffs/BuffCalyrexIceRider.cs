using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffCalyrexIceRider : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Calyrex!");
			Description.SetDefault("Calyrex was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("CalyrexIceRider")] > 0) {
				modPlayer.summonedCalyrexIceRider = true;
			}
			if (!modPlayer.summonedCalyrexIceRider) {
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
				player.statDefense += 15;
			}
			else
			{
				player.statDefense += 13;
			}
			
			player.statLifeMax2 += 165;
			player.meleeDamage *= 2.6f;
			player.rangedDamage *= 2.6f;
			player.magicDamage *= 1.9f;
			player.minionDamage *= 1.9f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}