using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCrobat : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Crobat!");
			Description.SetDefault("+85 HP\n+18% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+14% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.7 Speed\nPoison Type: Unimplemented Effect\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Crobat")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCrobat = true;
				modPlayer.buffPoisonType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedCrobat || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPoisonType = false;
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 85;
			player.meleeDamage *= 1.18f;
			player.rangedDamage *= 1.18f;
			player.magicDamage *= 1.14f;
			player.minionDamage *= 1.14f;
			player.maxRunSpeed += 0.7f;
			
			//modPlayer.numSpawned++;
		}
	}
}