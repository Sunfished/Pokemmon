using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMrMime : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Mr. Mime!");
			Description.SetDefault("+40 HP\n+9% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+20% Magic/Summon Damage\n+12 Magic/Summon Defense\n+0.5 Speed\nPsychic Type: Regens Mana faster\nFairy Type: Regens HP during nighttime");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("MrMime")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMrMime = true;
				modPlayer.buffPsychicType = true;
				modPlayer.buffFairyType = true;
			}
			if (!modPlayer.summonedMrMime || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPsychicType = false;
				modPlayer.buffFairyType = false;
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
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 12;
			}
			
			player.statLifeMax2 += 40;
			player.meleeDamage *= 1.09f;
			player.rangedDamage *= 1.09f;
			player.magicDamage *= 1.2f;
			player.minionDamage *= 1.2f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}