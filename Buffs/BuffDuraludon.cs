using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffDuraludon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Duraludon!");
			Description.SetDefault("Duraludon was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Duraludon")] > 0) {
				modPlayer.summonedDuraludon = true;
			}
			if (!modPlayer.summonedDuraludon) {
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
				player.statDefense += 11;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 95;
			player.meleeDamage *= 1.9f;
			player.rangedDamage *= 1.9f;
			player.magicDamage *= 2.2f;
			player.minionDamage *= 2.2f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}