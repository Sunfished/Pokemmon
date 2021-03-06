using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffLopunnyMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Lopunny!");
			Description.SetDefault("+65 HP\n+27% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+10% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.7 Speed\nNormal Type: Unimplemented Effect\nFighting Type: Increases DMG when HP > 50%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("LopunnyMega")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedLopunnyMega = true;
				modPlayer.buffNormalType = true;
				modPlayer.buffFightingType = true;
			}
			if (!modPlayer.summonedLopunnyMega || modPlayer.pokemonAmount > 1) {
				modPlayer.buffNormalType = false;
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
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 65;
			player.meleeDamage *= 1.27f;
			player.rangedDamage *= 1.27f;
			player.magicDamage *= 1.1f;
			player.minionDamage *= 1.1f;
			player.maxRunSpeed += 0.7f;
			
			//modPlayer.numSpawned++;
		}
	}
}