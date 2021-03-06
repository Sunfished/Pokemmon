using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffTepig : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Tepig!");
			Description.SetDefault("+65 HP\n+12% Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+9% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.2 Speed\nFire Type: Lights up area");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Tepig")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedTepig = true;
				modPlayer.buffFireType = true;
			}
			if (!modPlayer.summonedTepig || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 65;
			player.meleeDamage *= 1.12f;
			player.rangedDamage *= 1.12f;
			player.magicDamage *= 1.09f;
			player.minionDamage *= 1.09f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}