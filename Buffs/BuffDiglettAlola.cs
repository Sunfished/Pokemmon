using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffDiglettAlola : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Diglett!");
			Description.SetDefault("+10 HP\n+11% Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+7% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.5 Speed\nGround Type: Nullifies Knockback\nSteel Type: Decreases incoming DMG by 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("DiglettAlola")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedDiglettAlola = true;
				modPlayer.buffGroundType = true;
				modPlayer.buffSteelType = true;
			}
			if (!modPlayer.summonedDiglettAlola || modPlayer.pokemonAmount > 1) {
				modPlayer.buffGroundType = false;
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
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 10;
			player.meleeDamage *= 1.11f;
			player.rangedDamage *= 1.11f;
			player.magicDamage *= 1.07f;
			player.minionDamage *= 1.07f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}