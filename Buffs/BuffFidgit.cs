using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffFidgit : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Fidgit!");
			Description.SetDefault("+95 HP\n+15% Melee/Ranged Damage\n+10 Melee/Ranged Defense\n+18% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.5 Speed\nPoison Type: Unimplemented Effect\nGround Type: Nullifies Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Fidgit")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedFidgit = true;
				modPlayer.buffPoisonType = true;
				modPlayer.buffGroundType = true;
			}
			if (!modPlayer.summonedFidgit || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPoisonType = false;
				modPlayer.buffGroundType = false;
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
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 95;
			player.meleeDamage *= 1.15f;
			player.rangedDamage *= 1.15f;
			player.magicDamage *= 1.18f;
			player.minionDamage *= 1.18f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}