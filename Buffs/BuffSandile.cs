using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSandile : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Sandile!");
			Description.SetDefault("+50 HP\n+14% Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+7% Magic/Summon Damage\n+3 Magic/Summon Defense\n+0.3 Speed\nGround Type: Nullifies Knockback\nDark Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Sandile")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSandile = true;
				modPlayer.buffGroundType = true;
				modPlayer.buffDarkType = true;
			}
			if (!modPlayer.summonedSandile || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGroundType = false;
				modPlayer.buffDarkType = false;
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
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 50;
			player.meleeDamage *= 1.14f;
			player.rangedDamage *= 1.14f;
			player.magicDamage *= 1.07f;
			player.minionDamage *= 1.07f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}