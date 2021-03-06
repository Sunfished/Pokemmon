using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffYanmega : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Yanmega!");
			Description.SetDefault("+86 HP\n+15% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+23% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.5 Speed\nBug Type: Unimplemented Effect\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Yanmega")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedYanmega = true;
				modPlayer.buffBugType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedYanmega || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
				modPlayer.buffFlyingType = false;
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
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 86;
			player.meleeDamage *= 1.15f;
			player.rangedDamage *= 1.15f;
			player.magicDamage *= 1.23f;
			player.minionDamage *= 1.23f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}