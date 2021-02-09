using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffZapdosGalar : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Zapdos!");
			Description.SetDefault("+90 HP\n+25% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+17% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.5 Speed\nFighting Type: Increases DMG when HP > 50%\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("ZapdosGalar")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedZapdosGalar = true;
				modPlayer.buffFightingType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedZapdosGalar || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFightingType = false;
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
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 90;
			player.meleeDamage *= 1.25f;
			player.rangedDamage *= 1.25f;
			player.magicDamage *= 1.17f;
			player.minionDamage *= 1.17f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}