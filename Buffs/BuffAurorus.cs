using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffAurorus : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Aurorus!");
			Description.SetDefault("+123 HP\n+15% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+19% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.3 Speed\nRock Type: Increases Knockback\nIce Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Aurorus")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedAurorus = true;
				modPlayer.buffRockType = true;
				modPlayer.buffIceType = true;
			}
			if (!modPlayer.summonedAurorus || modPlayer.pokemonAmount > 1) {
				modPlayer.buffRockType = false;
				modPlayer.buffIceType = false;
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
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 123;
			player.meleeDamage *= 1.15f;
			player.rangedDamage *= 1.15f;
			player.magicDamage *= 1.19f;
			player.minionDamage *= 1.19f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}