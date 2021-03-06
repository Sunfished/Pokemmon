using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMarowakAlola : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Marowak!");
			Description.SetDefault("+60 HP\n+16% Melee/Ranged Damage\n+11 Melee/Ranged Defense\n+10% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.2 Speed\nFire Type: Lights up area\nGhost Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("MarowakAlola")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMarowakAlola = true;
				modPlayer.buffFireType = true;
				modPlayer.buffGhostType = true;
			}
			if (!modPlayer.summonedMarowakAlola || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFireType = false;
				modPlayer.buffGhostType = false;
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
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 60;
			player.meleeDamage *= 1.16f;
			player.rangedDamage *= 1.16f;
			player.magicDamage *= 1.1f;
			player.minionDamage *= 1.1f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}