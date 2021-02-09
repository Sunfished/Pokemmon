using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffVoodoom : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Voodoom!");
			Description.SetDefault("+90 HP\n+17% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+21% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.6 Speed\nFighting Type: Increases DMG when HP > 50%\nDark Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Voodoom")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedVoodoom = true;
				modPlayer.buffFightingType = true;
				modPlayer.buffDarkType = true;
			}
			if (!modPlayer.summonedVoodoom || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFightingType = false;
				modPlayer.buffDarkType = false;
				player.DelBuff(buffIndex);
				buffIndex--;
				modPlayer.pokemonAmount = 0;
			}
		
			//Calc Buffs
			var isMelee = true;
			if(player.magicDamage > player.meleeDamage || player.magicDamage > player.rangedDamage ||
			player.minionDamage > player.meleeDamage || player.minionDamage > player.rangedDamage)
				isMelee = false;
			if (isMelee)
			{
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 90;
			player.meleeDamage *= 1.17f;
			player.rangedDamage *= 1.17f;
			player.magicDamage *= 1.21f;
			player.minionDamage *= 1.21f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}