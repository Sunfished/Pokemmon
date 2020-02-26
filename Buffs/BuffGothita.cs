using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffGothita : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Gothita!");
			Description.SetDefault("Gothita was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Gothita")] > 0) {
				modPlayer.summonedGothita = true;
			}
			if (!modPlayer.summonedGothita) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
		public override void PostUpdate(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
		
			//Calc Buffs
			player.meleeDamage *= 1.3f;
			player.rangedDamage *= 1.3f;
			player.magicDamage *= 1.6f;
			player.maxRunSpeed += 0.2f
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 5;
			}
			else if (player.magicDamage >= player.minionDamage)
			{
				player.statDefense += 6;
			}
		}
	}
}