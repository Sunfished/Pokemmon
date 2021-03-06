using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffKyurem : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Kyurem!");
			Description.SetDefault("+125 HP\n+26% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+26% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.5 Speed\nDragon Type: Multitude of effects when HP < 20%\nIce Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Kyurem")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedKyurem = true;
				modPlayer.buffDragonType = true;
				modPlayer.buffIceType = true;
			}
			if (!modPlayer.summonedKyurem || modPlayer.pokemonAmount > 1) {
				modPlayer.buffDragonType = false;
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
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 125;
			player.meleeDamage *= 1.26f;
			player.rangedDamage *= 1.26f;
			player.magicDamage *= 1.26f;
			player.minionDamage *= 1.26f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}