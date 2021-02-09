using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffHaxorus : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Haxorus!");
			Description.SetDefault("+76 HP\n+29% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+12% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.5 Speed\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Haxorus")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedHaxorus = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedHaxorus || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 76;
			player.meleeDamage *= 1.29f;
			player.rangedDamage *= 1.29f;
			player.magicDamage *= 1.12f;
			player.minionDamage *= 1.12f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}