using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffBastiodon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Bastiodon!");
			Description.SetDefault("+60 HP\n+10% Melee/Ranged Damage\n+16 Melee/Ranged Defense\n+9% Magic/Summon Damage\n+13 Magic/Summon Defense\n+0.1 Speed\nRock Type: Increases Knockback\nSteel Type: Decreases incoming DMG by 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Bastiodon")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedBastiodon = true;
				modPlayer.buffRockType = true;
				modPlayer.buffSteelType = true;
			}
			if (!modPlayer.summonedBastiodon || modPlayer.pokemonAmount > 1) {
				modPlayer.buffRockType = false;
				modPlayer.buffSteelType = false;
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
				player.statDefense += 16;
			}
			else
			{
				player.statDefense += 13;
			}
			
			player.statLifeMax2 += 60;
			player.meleeDamage *= 1.1f;
			player.rangedDamage *= 1.1f;
			player.magicDamage *= 1.09f;
			player.minionDamage *= 1.09f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}