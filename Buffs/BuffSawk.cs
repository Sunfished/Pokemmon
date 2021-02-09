using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSawk : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Sawk!");
			Description.SetDefault("+75 HP\n+25% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+6% Magic/Summon Damage\n+7 Magic/Summon Defense\n+0.4 Speed\nFighting Type: Increases DMG when HP > 50%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Sawk")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSawk = true;
				modPlayer.buffFightingType = true;
			}
			if (!modPlayer.summonedSawk || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFightingType = false;
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
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 7;
			}
			
			player.statLifeMax2 += 75;
			player.meleeDamage *= 1.25f;
			player.rangedDamage *= 1.25f;
			player.magicDamage *= 1.06f;
			player.minionDamage *= 1.06f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}