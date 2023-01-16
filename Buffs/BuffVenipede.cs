using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffVenipede : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Venipede!");
			Description.SetDefault("+30 HP\n+9% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+6% Magic/Summon Damage\n+3 Magic/Summon Defense\n+0.3 Speed\nBug Type: Unimplemented Effect\nPoison Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Venipede").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedVenipede = true;
				modPlayer.buffBugType = true;
				modPlayer.buffPoisonType = true;
			}
			if (!modPlayer.summonedVenipede || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
				modPlayer.buffPoisonType = false;
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 30;
			player.GetDamage(DamageClass.Melee) *= 1.09f;
			player.GetDamage(DamageClass.Ranged) *= 1.09f;
			player.GetDamage(DamageClass.Magic) *= 1.06f;
			player.GetDamage(DamageClass.Summon) *= 1.06f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}