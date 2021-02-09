using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffHappiny : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Happiny!");
			Description.SetDefault("+100 HP\n+1% Melee/Ranged Damage\n+0 Melee/Ranged Defense\n+3% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.1 Speed\nNormal Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Happiny")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedHappiny = true;
				modPlayer.buffNormalType = true;
			}
			if (!modPlayer.summonedHappiny || modPlayer.pokemonAmount > 1) {
				modPlayer.buffNormalType = false;
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
				player.statDefense += 0;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 100;
			player.meleeDamage *= 1.01f;
			player.rangedDamage *= 1.01f;
			player.magicDamage *= 1.03f;
			player.minionDamage *= 1.03f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}