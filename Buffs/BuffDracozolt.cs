using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffDracozolt : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Dracozolt!");
			Description.SetDefault("+90 HP\n+20% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+16% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.4 Speed\nElectric Type: Unimplemented Effect\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Dracozolt")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedDracozolt = true;
				modPlayer.buffElectricType = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedDracozolt || modPlayer.pokemonAmount > 1) {
				modPlayer.buffElectricType = false;
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
			
			player.statLifeMax2 += 90;
			player.meleeDamage *= 1.2f;
			player.rangedDamage *= 1.2f;
			player.magicDamage *= 1.16f;
			player.minionDamage *= 1.16f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}