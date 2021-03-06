using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffPineco : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Pineco!");
			Description.SetDefault("+50 HP\n+13% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+7% Magic/Summon Damage\n+3 Magic/Summon Defense\n+0.1 Speed\nBug Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Pineco")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedPineco = true;
				modPlayer.buffBugType = true;
			}
			if (!modPlayer.summonedPineco || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 50;
			player.meleeDamage *= 1.13f;
			player.rangedDamage *= 1.13f;
			player.magicDamage *= 1.07f;
			player.minionDamage *= 1.07f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}