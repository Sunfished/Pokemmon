using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffPelipper : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Pelipper!");
			Description.SetDefault("+60 HP\n+10% Melee/Ranged Damage\n+10 Melee/Ranged Defense\n+19% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.3 Speed\nWater Type: Allows swimming and water breathing\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Pelipper")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedPelipper = true;
				modPlayer.buffWaterType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedPelipper || modPlayer.pokemonAmount > 1) {
				modPlayer.buffWaterType = false;
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
				player.statDefense += 10;
			}
			else
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 60;
			player.meleeDamage *= 1.1f;
			player.rangedDamage *= 1.1f;
			player.magicDamage *= 1.19f;
			player.minionDamage *= 1.19f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}