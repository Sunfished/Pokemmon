using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMetapod : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Metapod!");
			Description.SetDefault("+50 HP\n+4% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+5% Magic/Summon Damage\n+2 Magic/Summon Defense\n+0.1 Speed\nBug Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Metapod")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMetapod = true;
				modPlayer.buffBugType = true;
			}
			if (!modPlayer.summonedMetapod || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 2;
			}
			
			player.statLifeMax2 += 50;
			player.meleeDamage *= 1.04f;
			player.rangedDamage *= 1.04f;
			player.magicDamage *= 1.05f;
			player.minionDamage *= 1.05f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}