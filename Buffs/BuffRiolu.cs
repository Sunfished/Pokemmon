using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffRiolu : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Riolu!");
			Description.SetDefault("+40 HP\n+14% Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+7% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.3 Speed\nFighting Type: Increases DMG when HP > 50%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Riolu")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedRiolu = true;
				modPlayer.buffFightingType = true;
			}
			if (!modPlayer.summonedRiolu || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFightingType = false;
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
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 40;
			player.meleeDamage *= 1.14f;
			player.rangedDamage *= 1.14f;
			player.magicDamage *= 1.07f;
			player.minionDamage *= 1.07f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}