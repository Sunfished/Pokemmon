using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffEquilibra : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Equilibra!");
			Description.SetDefault("+102 HP\n+10% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+26% Magic/Summon Damage\n+11 Magic/Summon Defense\n+0.3 Speed\nSteel Type: Decreases incoming DMG by 20%\nGround Type: Nullifies Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Equilibra")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedEquilibra = true;
				modPlayer.buffSteelType = true;
				modPlayer.buffGroundType = true;
			}
			if (!modPlayer.summonedEquilibra || modPlayer.pokemonAmount > 1) {
				modPlayer.buffSteelType = false;
				modPlayer.buffGroundType = false;
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
				player.statDefense += 11;
			}
			
			player.statLifeMax2 += 102;
			player.meleeDamage *= 1.1f;
			player.rangedDamage *= 1.1f;
			player.magicDamage *= 1.26f;
			player.minionDamage *= 1.26f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}