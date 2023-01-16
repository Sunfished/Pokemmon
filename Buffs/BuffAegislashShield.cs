using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffAegislashShield : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Aegislash!");
			Description.SetDefault("+60 HP\n+10% Melee/Ranged Damage\n+14 Melee/Ranged Defense\n+10% Magic/Summon Damage\n+14 Magic/Summon Defense\n+0.3 Speed\nSteel Type: Decreases incoming DMG by 20%\nGhost Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("AegislashShield").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedAegislashShield = true;
				modPlayer.buffSteelType = true;
				modPlayer.buffGhostType = true;
			}
			if (!modPlayer.summonedAegislashShield || modPlayer.pokemonAmount > 1) {
				modPlayer.buffSteelType = false;
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
				player.statDefense += 14;
			}
			else
			{
				player.statDefense += 14;
			}
			
			player.statLifeMax2 += 60;
			player.GetDamage(DamageClass.Melee) *= 1.1f;
			player.GetDamage(DamageClass.Ranged) *= 1.1f;
			player.GetDamage(DamageClass.Magic) *= 1.1f;
			player.GetDamage(DamageClass.Summon) *= 1.1f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}