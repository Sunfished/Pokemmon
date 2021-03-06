using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffGravelerAlola : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Graveler!");
			Description.SetDefault("+55 HP\n+19% Melee/Ranged Damage\n+11 Melee/Ranged Defense\n+9% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.2 Speed\nRock Type: Increases Knockback\nElectric Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("GravelerAlola")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedGravelerAlola = true;
				modPlayer.buffRockType = true;
				modPlayer.buffElectricType = true;
			}
			if (!modPlayer.summonedGravelerAlola || modPlayer.pokemonAmount > 1) {
				modPlayer.buffRockType = false;
				modPlayer.buffElectricType = false;
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
				player.statDefense += 11;
			}
			else
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 55;
			player.meleeDamage *= 1.19f;
			player.rangedDamage *= 1.19f;
			player.magicDamage *= 1.09f;
			player.minionDamage *= 1.09f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}