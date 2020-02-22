using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffEeveeGigantamax : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Eevee!");
			Description.SetDefault("Eevee was sent out!");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("EeveeGigantamax")] > 0) {
				modPlayer.summonedEeveeGigantamax = true;
			}
			if (!modPlayer.summonedEeveeGigantamax) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
			
			//Calc Buffs
			if (player.meleeDamage >= player.magicDamage || player.rangedDamage >= player.magicDamage)
			{
				player.statDefense += 0;
			}
			else
			{
				player.statDefense += 0;
			}
		}
	}
}