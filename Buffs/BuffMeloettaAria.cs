using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffMeloettaAria : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Meloetta!");
			Description.SetDefault("Meloetta was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("MeloettaAria")] > 0) {
				modPlayer.summonedMeloettaAria = true;
			}
			if (!modPlayer.summonedMeloettaAria) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 7;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 12;
			}
			
			player.statLifeMax2 += 77;
			player.meleeDamage *= 1.8f;
			player.rangedDamage *= 1.8f;
			player.magicDamage *= 2.3f;
			player.maxRunSpeed += 0.5f;
		}

	}
}