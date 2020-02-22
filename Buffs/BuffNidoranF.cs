using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffNidoranF : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Nidoran-F!");
			Description.SetDefault("Nidoran-F was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("NidoranF")] > 0) {
				modPlayer.summonedNidoranF = true;
			}
			if (!modPlayer.summonedNidoranF) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 4;
			}
		}
	}
}