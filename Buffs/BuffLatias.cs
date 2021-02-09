using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffLatias : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Latias!");
			Description.SetDefault("+80 HP\n+16% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+22% Magic/Summon Damage\n+13 Magic/Summon Defense\n+0.6 Speed\nDragon Type: Multitude of effects when HP < 20%\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Latias")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedLatias = true;
				modPlayer.buffDragonType = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedLatias || modPlayer.pokemonAmount > 1) {
				modPlayer.buffDragonType = false;
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
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 13;
			}
			
			player.statLifeMax2 += 80;
			player.meleeDamage *= 1.16f;
			player.rangedDamage *= 1.16f;
			player.magicDamage *= 1.22f;
			player.minionDamage *= 1.22f;
			player.maxRunSpeed += 0.6f;
			
			//modPlayer.numSpawned++;
		}
	}
}