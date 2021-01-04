using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffExcadrill : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Excadrill!");
			Description.SetDefault("Excadrill was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Excadrill")] > 0) {
				modPlayer.summonedExcadrill = true;
			}
			if (!modPlayer.summonedExcadrill) {
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
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 135;
			player.meleeDamage *= 2.4f;
			player.rangedDamage *= 2.4f;
			player.magicDamage *= 1.5f;
			player.minionDamage *= 1.5f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}