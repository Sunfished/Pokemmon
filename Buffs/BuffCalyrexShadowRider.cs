using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffCalyrexShadowRider : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Calyrex!");
			Description.SetDefault("Calyrex was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("CalyrexShadowRider")] > 0) {
				modPlayer.summonedCalyrexShadowRider = true;
			}
			if (!modPlayer.summonedCalyrexShadowRider) {
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 85;
			player.meleeDamage *= 1.9f;
			player.rangedDamage *= 1.9f;
			player.magicDamage *= 2.6f;
			player.minionDamage *= 2.6f;
			player.maxRunSpeed += 0.8f;
			
			//modPlayer.numSpawned++;
		}
	}
}