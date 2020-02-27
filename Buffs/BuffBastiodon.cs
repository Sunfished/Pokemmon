using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffBastiodon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Bastiodon!");
			Description.SetDefault("Bastiodon was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Bastiodon")] > 0) {
				modPlayer.summonedBastiodon = true;
			}
			if (!modPlayer.summonedBastiodon) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 16;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 13;
			}
			
			player.statLifeMax2 += 52;
			player.meleeDamage *= 1.5f;
			player.rangedDamage *= 1.5f;
			player.magicDamage *= 1.5f;
			player.maxRunSpeed += 0.1f;
		}

	}
}