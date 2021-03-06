using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffDottler : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Dottler!");
			Description.SetDefault("+50 HP\n+7% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+10% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.1 Speed\nBug Type: Unimplemented Effect\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Dottler")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedDottler = true;
				modPlayer.buffBugType = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedDottler || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 50;
			player.meleeDamage *= 1.07f;
			player.rangedDamage *= 1.07f;
			player.magicDamage *= 1.1f;
			player.minionDamage *= 1.1f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}