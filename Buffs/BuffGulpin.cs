using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffGulpin : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Gulpin!");
			Description.SetDefault("+70 HP\n+8% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+8% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.2 Speed\nPoison Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Gulpin")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedGulpin = true;
				modPlayer.buffPoisonType = true;
			}
			if (!modPlayer.summonedGulpin || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 70;
			player.meleeDamage *= 1.08f;
			player.rangedDamage *= 1.08f;
			player.magicDamage *= 1.08f;
			player.minionDamage *= 1.08f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}