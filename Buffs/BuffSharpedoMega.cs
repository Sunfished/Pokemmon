using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSharpedoMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Sharpedo!");
			Description.SetDefault("Sharpedo was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("SharpedoMega")] > 0) {
				modPlayer.summonedSharpedoMega = true;
			}
			if (!modPlayer.summonedSharpedoMega) {
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
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 140;
			player.meleeDamage *= 2.4f;
			player.rangedDamage *= 2.4f;
			player.magicDamage *= 2.1f;
			player.minionDamage *= 2.1f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}