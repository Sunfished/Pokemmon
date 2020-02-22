using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffSandshrewAlola : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Sandshrew!");
			Description.SetDefault("Sandshrew was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("SandshrewAlola")] > 0) {
				modPlayer.summonedSandshrewAlola = true;
			}
			if (!modPlayer.summonedSandshrewAlola) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 3;
			}
		}
	}
}