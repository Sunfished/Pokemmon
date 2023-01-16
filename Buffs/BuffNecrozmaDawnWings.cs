using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffNecrozmaDawnWings : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Necrozma!");
			Description.SetDefault("+97 HP\n+22% Melee/Ranged Damage\n+10 Melee/Ranged Defense\n+30% Magic/Summon Damage\n+12 Magic/Summon Defense\n+0.4 Speed\nPsychic Type: Regens Mana faster\nGhost Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("NecrozmaDawnWings").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedNecrozmaDawnWings = true;
				modPlayer.buffPsychicType = true;
				modPlayer.buffGhostType = true;
			}
			if (!modPlayer.summonedNecrozmaDawnWings || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPsychicType = false;
				modPlayer.buffGhostType = false;
				player.DelBuff(buffIndex);
				buffIndex--;
				modPlayer.pokemonAmount = 0;
			}
		
			//Calc Buffs
			var isMelee = true;
			if(player.GetDamage(DamageClass.Magic).Flat > player.GetDamage(DamageClass.Melee).Flat || player.GetDamage(DamageClass.Magic).Flat > player.GetDamage(DamageClass.Ranged).Flat ||
			player.GetDamage(DamageClass.Summon).Flat > player.GetDamage(DamageClass.Melee).Flat || player.GetDamage(DamageClass.Summon).Flat > player.GetDamage(DamageClass.Ranged).Flat)
				isMelee = false;
			if (isMelee)
			{
				player.statDefense += 10;
			}
			else
			{
				player.statDefense += 12;
			}
			
			player.statLifeMax2 += 97;
			player.GetDamage(DamageClass.Melee) *= 1.22f;
			player.GetDamage(DamageClass.Ranged) *= 1.22f;
			player.GetDamage(DamageClass.Magic) *= 1.3f;
			player.GetDamage(DamageClass.Summon) *= 1.3f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}