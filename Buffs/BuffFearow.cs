using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffFearow : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Fearow!");
			Description.SetDefault("+65 HP\n+18% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+12% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.5 Speed\nNormal Type: Unimplemented Effect\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Fearow")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedFearow = true;
				modPlayer.buffNormalType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedFearow || modPlayer.pokemonAmount > 1) {
				modPlayer.buffNormalType = false;
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
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 65;
			player.meleeDamage *= 1.18f;
			player.rangedDamage *= 1.18f;
			player.magicDamage *= 1.12f;
			player.minionDamage *= 1.12f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}