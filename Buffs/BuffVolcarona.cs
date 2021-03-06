using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffVolcarona : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Volcarona!");
			Description.SetDefault("+85 HP\n+12% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+27% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.5 Speed\nBug Type: Unimplemented Effect\nFire Type: Lights up area");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Volcarona")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedVolcarona = true;
				modPlayer.buffBugType = true;
				modPlayer.buffFireType = true;
			}
			if (!modPlayer.summonedVolcarona || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
				modPlayer.buffFireType = false;
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
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 85;
			player.meleeDamage *= 1.12f;
			player.rangedDamage *= 1.12f;
			player.magicDamage *= 1.27f;
			player.minionDamage *= 1.27f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}