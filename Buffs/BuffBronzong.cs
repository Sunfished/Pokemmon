using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffBronzong : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Bronzong!");
			Description.SetDefault("+67 HP\n+17% Melee/Ranged Damage\n+11 Melee/Ranged Defense\n+15% Magic/Summon Damage\n+11 Magic/Summon Defense\n+0.2 Speed\nSteel Type: Decreases incoming DMG by 20%\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Bronzong")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedBronzong = true;
				modPlayer.buffSteelType = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedBronzong || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 11;
			}
			else
			{
				player.statDefense += 11;
			}
			
			player.statLifeMax2 += 67;
			player.meleeDamage *= 1.17f;
			player.rangedDamage *= 1.17f;
			player.magicDamage *= 1.15f;
			player.minionDamage *= 1.15f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}