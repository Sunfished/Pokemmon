using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffRaticateAlola : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Raticate!");
			Description.SetDefault("+75 HP\n+14% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+8% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.4 Speed\nDark Type: Unimplemented Effect\nNormal Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("RaticateAlola")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedRaticateAlola = true;
				modPlayer.buffDarkType = true;
				modPlayer.buffNormalType = true;
			}
			if (!modPlayer.summonedRaticateAlola || modPlayer.pokemonAmount > 1) {
				modPlayer.buffDarkType = false;
				modPlayer.buffNormalType = false;
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
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 75;
			player.meleeDamage *= 1.14f;
			player.rangedDamage *= 1.14f;
			player.magicDamage *= 1.08f;
			player.minionDamage *= 1.08f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}