using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffEkans : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Ekans!");
			Description.SetDefault("+30 HP\n+12% Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+8% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.3 Speed\nPoison Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Ekans")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedEkans = true;
				modPlayer.buffPoisonType = true;
			}
			if (!modPlayer.summonedEkans || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPoisonType = false;
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
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 30;
			player.meleeDamage *= 1.12f;
			player.rangedDamage *= 1.12f;
			player.magicDamage *= 1.08f;
			player.minionDamage *= 1.08f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}