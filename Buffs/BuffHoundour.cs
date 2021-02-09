using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffHoundour : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Houndour!");
			Description.SetDefault("+45 HP\n+12% Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+16% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.3 Speed\nDark Type: Unimplemented Effect\nFire Type: Lights up area");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Houndour")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedHoundour = true;
				modPlayer.buffDarkType = true;
				modPlayer.buffFireType = true;
			}
			if (!modPlayer.summonedHoundour || modPlayer.pokemonAmount > 1) {
				modPlayer.buffDarkType = false;
				modPlayer.buffFireType = false;
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
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 45;
			player.meleeDamage *= 1.12f;
			player.rangedDamage *= 1.12f;
			player.magicDamage *= 1.16f;
			player.minionDamage *= 1.16f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}