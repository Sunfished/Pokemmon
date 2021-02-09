using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMelmetal : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Melmetal!");
			Description.SetDefault("+135 HP\n+28% Melee/Ranged Damage\n+14 Melee/Ranged Defense\n+16% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.2 Speed\nSteel Type: Decreases incoming DMG by 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Melmetal")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMelmetal = true;
				modPlayer.buffSteelType = true;
			}
			if (!modPlayer.summonedMelmetal || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 14;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 135;
			player.meleeDamage *= 1.28f;
			player.rangedDamage *= 1.28f;
			player.magicDamage *= 1.16f;
			player.minionDamage *= 1.16f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}