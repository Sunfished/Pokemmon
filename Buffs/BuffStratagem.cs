using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffStratagem : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Stratagem!");
			Description.SetDefault("Stratagem was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Stratagem")] > 0) {
				modPlayer.summonedStratagem = true;
			}
			if (!modPlayer.summonedStratagem) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 7;
			}
		}
	}
}