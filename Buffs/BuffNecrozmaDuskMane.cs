using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffNecrozmaDuskMane : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Necrozma!");
			Description.SetDefault("+97 HP\n+30% Melee/Ranged Damage\n+12 Melee/Ranged Defense\n+22% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.4 Speed\nPsychic Type: Regens Mana faster\nSteel Type: Decreases incoming DMG by 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("NecrozmaDuskMane")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedNecrozmaDuskMane = true;
				modPlayer.buffPsychicType = true;
				modPlayer.buffSteelType = true;
			}
			if (!modPlayer.summonedNecrozmaDuskMane || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPsychicType = false;
				modPlayer.buffSteelType = false;
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
				player.statDefense += 12;
			}
			else
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 97;
			player.meleeDamage *= 1.3f;
			player.rangedDamage *= 1.3f;
			player.magicDamage *= 1.22f;
			player.minionDamage *= 1.22f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}