using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffNoibat : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Noibat!");
			Description.SetDefault("+40 HP\n+6% Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+9% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.3 Speed\nFlying Type: Descends slowly in the air\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Noibat")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedNoibat = true;
				modPlayer.buffFlyingType = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedNoibat || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFlyingType = false;
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
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 40;
			player.meleeDamage *= 1.06f;
			player.rangedDamage *= 1.06f;
			player.magicDamage *= 1.09f;
			player.minionDamage *= 1.09f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}