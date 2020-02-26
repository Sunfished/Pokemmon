using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffMonohm : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Monohm!");
			Description.SetDefault("Monohm was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Monohm")] > 0) {
				modPlayer.summonedMonohm = true;
			}
			if (!modPlayer.summonedMonohm) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
		public override void PostUpdate(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
		
			//Calc Buffs
			player.meleeDamage *= 0f;
			player.rangedDamage *= 0f;
			player.magicDamage *= 0f;
			player.maxRunSpeed += 0f
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 0;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 0;
			}
		}
	}
}