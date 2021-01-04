using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffAvalugg : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Avalugg!");
			Description.SetDefault("Avalugg was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Avalugg")] > 0) {
				modPlayer.summonedAvalugg = true;
			}
			if (!modPlayer.summonedAvalugg) {
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
				player.statDefense += 18;
			}
			else
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 117;
			player.meleeDamage *= 2.2f;
			player.rangedDamage *= 2.2f;
			player.magicDamage *= 1.4f;
			player.minionDamage *= 1.4f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}