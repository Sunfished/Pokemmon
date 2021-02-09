using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffLitleo : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Litleo!");
			Description.SetDefault("+62 HP\n+10% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+14% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.4 Speed\nFire Type: Lights up area\nNormal Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Litleo")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedLitleo = true;
				modPlayer.buffFireType = true;
				modPlayer.buffNormalType = true;
			}
			if (!modPlayer.summonedLitleo || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFireType = false;
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 62;
			player.meleeDamage *= 1.1f;
			player.rangedDamage *= 1.1f;
			player.magicDamage *= 1.14f;
			player.minionDamage *= 1.14f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}