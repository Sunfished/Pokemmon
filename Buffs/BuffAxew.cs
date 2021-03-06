using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffAxew : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Axew!");
			Description.SetDefault("+46 HP\n+17% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+6% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.3 Speed\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Axew")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedAxew = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedAxew || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 46;
			player.meleeDamage *= 1.17f;
			player.rangedDamage *= 1.17f;
			player.magicDamage *= 1.06f;
			player.minionDamage *= 1.06f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}