using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSalamenceMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Salamence!");
			Description.SetDefault("+95 HP\n+29% Melee/Ranged Damage\n+13 Melee/Ranged Defense\n+24% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.6 Speed\nDragon Type: Multitude of effects when HP < 20%\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("SalamenceMega")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSalamenceMega = true;
				modPlayer.buffDragonType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedSalamenceMega || modPlayer.pokemonAmount > 1) {
				modPlayer.buffDragonType = false;
				modPlayer.buffFlyingType = false;
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
				player.statDefense += 13;
			}
			else
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 95;
			player.meleeDamage *= 1.29f;
			player.rangedDamage *= 1.29f;
			player.magicDamage *= 1.24f;
			player.minionDamage *= 1.24f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}