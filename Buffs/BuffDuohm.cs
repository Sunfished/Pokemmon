using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffDuohm : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Duohm!");
			Description.SetDefault("+88 HP\n+8% Melee/Ranged Damage\n+10 Melee/Ranged Defense\n+15% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.3 Speed\nElectric Type: Unimplemented Effect\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Duohm")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedDuohm = true;
				modPlayer.buffElectricType = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedDuohm || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 10;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 88;
			player.meleeDamage *= 1.08f;
			player.rangedDamage *= 1.08f;
			player.magicDamage *= 1.15f;
			player.minionDamage *= 1.15f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}