using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffNickit : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Nickit!");
			Description.SetDefault("+40 HP\n+5% Melee/Ranged Damage\n+2 Melee/Ranged Defense\n+9% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.2 Speed\nDark Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Nickit")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedNickit = true;
				modPlayer.buffDarkType = true;
			}
			if (!modPlayer.summonedNickit || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 2;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 40;
			player.meleeDamage *= 1.05f;
			player.rangedDamage *= 1.05f;
			player.magicDamage *= 1.09f;
			player.minionDamage *= 1.09f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}