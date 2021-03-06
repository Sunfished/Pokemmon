using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSliggoo : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Sliggoo!");
			Description.SetDefault("+68 HP\n+15% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+16% Magic/Summon Damage\n+11 Magic/Summon Defense\n+0.3 Speed\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Sliggoo")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSliggoo = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedSliggoo || modPlayer.pokemonAmount > 1) {
				modPlayer.buffDragonType = false;
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 11;
			}
			
			player.statLifeMax2 += 68;
			player.meleeDamage *= 1.15f;
			player.rangedDamage *= 1.15f;
			player.magicDamage *= 1.16f;
			player.minionDamage *= 1.16f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}