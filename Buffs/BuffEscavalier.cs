using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffEscavalier : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Escavalier!");
			Description.SetDefault("Escavalier was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Escavalier")] > 0) {
				modPlayer.summonedEscavalier = true;
			}
			if (!modPlayer.summonedEscavalier) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 10;
			}
			else
			{
				player.statDefense += 10;
			}
		}
	}
}