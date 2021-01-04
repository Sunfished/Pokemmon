using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffMewtwoMegaX : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Mewtwo!");
			Description.SetDefault("Mewtwo was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("MewtwoMegaX")] > 0) {
				modPlayer.summonedMewtwoMegaX = true;
			}
			if (!modPlayer.summonedMewtwoMegaX) {
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
				player.statDefense += 10;
			}
			else
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 190;
			player.meleeDamage *= 2.9f;
			player.rangedDamage *= 2.9f;
			player.magicDamage *= 2.5f;
			player.minionDamage *= 2.5f;
			player.maxRunSpeed += 0.7f;
			
			//modPlayer.numSpawned++;
		}
	}
}