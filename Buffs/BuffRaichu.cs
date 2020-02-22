using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffRaichu : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Raichu!");
			Description.SetDefault("Raichu was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Raichu")] > 0) {
				modPlayer.summonedRaichu = true;
			}
			if (!modPlayer.summonedRaichu) {
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
				player.statDefense += 8;
			}
		}
	}
}