using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffXerneas : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Xerneas!");
			Description.SetDefault("Xerneas was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Xerneas")] > 0) {
				modPlayer.summonedXerneas = true;
			}
			if (!modPlayer.summonedXerneas) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
		public override void PostUpdate(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
		
			//Calc Buffs
			player.meleeDamage *= 2.3f;
			player.rangedDamage *= 2.3f;
			player.magicDamage *= 2.3f;
			player.maxRunSpeed += 0.5f
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 9;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 9;
			}
		}
	}
}