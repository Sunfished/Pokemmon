using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMoltresGalar : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Moltres!");
			Description.SetDefault("+90 HP\n+17% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+20% Magic/Summon Damage\n+12 Magic/Summon Defense\n+0.5 Speed\nDark Type: Unimplemented Effect\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("MoltresGalar")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMoltresGalar = true;
				modPlayer.buffDarkType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedMoltresGalar || modPlayer.pokemonAmount > 1) {
				modPlayer.buffDarkType = false;
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
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 12;
			}
			
			player.statLifeMax2 += 90;
			player.meleeDamage *= 1.17f;
			player.rangedDamage *= 1.17f;
			player.magicDamage *= 1.2f;
			player.minionDamage *= 1.2f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}