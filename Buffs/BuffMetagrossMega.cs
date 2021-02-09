using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMetagrossMega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Metagross!");
			Description.SetDefault("+80 HP\n+29% Melee/Ranged Damage\n+15 Melee/Ranged Defense\n+21% Magic/Summon Damage\n+11 Magic/Summon Defense\n+0.6 Speed\nSteel Type: Decreases incoming DMG by 20%\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("MetagrossMega")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMetagrossMega = true;
				modPlayer.buffSteelType = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedMetagrossMega || modPlayer.pokemonAmount > 1) {
				modPlayer.buffSteelType = false;
				modPlayer.buffPsychicType = false;
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
				player.statDefense += 15;
			}
			else
			{
				player.statDefense += 11;
			}
			
			player.statLifeMax2 += 80;
			player.meleeDamage *= 1.29f;
			player.rangedDamage *= 1.29f;
			player.magicDamage *= 1.21f;
			player.minionDamage *= 1.21f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}