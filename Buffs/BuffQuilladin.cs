using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffQuilladin : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Quilladin!");
			Description.SetDefault("Quilladin was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Quilladin")] > 0) {
				modPlayer.summonedQuilladin = true;
			}
			if (!modPlayer.summonedQuilladin) {
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
				player.statDefense += 5;
			}
		}
	}
}