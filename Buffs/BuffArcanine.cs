using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffArcanine : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Arcanine!");
			Description.SetDefault("+90 HP\n+22% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+20% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.5 Speed\nFire Type: Lights up area");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Arcanine")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedArcanine = true;
				modPlayer.buffFireType = true;
			}
			if (!modPlayer.summonedArcanine || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 90;
			player.meleeDamage *= 1.22f;
			player.rangedDamage *= 1.22f;
			player.magicDamage *= 1.2f;
			player.minionDamage *= 1.2f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}