using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffRowlet : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Rowlet!");
			Description.SetDefault("+68 HP\n+11% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+10% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.2 Speed\nGrass Type: Regens HP during daytime\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Rowlet")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedRowlet = true;
				modPlayer.buffGrassType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedRowlet || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGrassType = false;
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 68;
			player.meleeDamage *= 1.11f;
			player.rangedDamage *= 1.11f;
			player.magicDamage *= 1.1f;
			player.minionDamage *= 1.1f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}