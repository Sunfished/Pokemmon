using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMeowthAlola : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Meowth!");
			Description.SetDefault("+40 HP\n+7% Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+10% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.5 Speed\nDark Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("MeowthAlola")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMeowthAlola = true;
				modPlayer.buffDarkType = true;
			}
			if (!modPlayer.summonedMeowthAlola || modPlayer.pokemonAmount > 1) {
				modPlayer.buffDarkType = false;
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
			
			player.statLifeMax2 += 40;
			player.meleeDamage *= 1.07f;
			player.rangedDamage *= 1.07f;
			player.magicDamage *= 1.1f;
			player.minionDamage *= 1.1f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}