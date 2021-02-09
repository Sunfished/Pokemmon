using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCalyrexShadowRider : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Calyrex!");
			Description.SetDefault("+100 HP\n+17% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+30% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.8 Speed\nPsychic Type: Regens Mana faster\nGhost Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("CalyrexShadowRider")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCalyrexShadowRider = true;
				modPlayer.buffPsychicType = true;
				modPlayer.buffGhostType = true;
			}
			if (!modPlayer.summonedCalyrexShadowRider || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPsychicType = false;
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 100;
			player.meleeDamage *= 1.17f;
			player.rangedDamage *= 1.17f;
			player.magicDamage *= 1.3f;
			player.minionDamage *= 1.3f;
			player.maxRunSpeed += 0.8f;
			
			//modPlayer.numSpawned++;
		}
	}
}