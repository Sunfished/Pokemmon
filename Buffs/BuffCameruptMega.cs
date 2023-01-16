using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCameruptMega : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Camerupt!");
			Description.SetDefault("+70 HP\n+24% Melee/Ranged Damage\n+10 Melee/Ranged Defense\n+29% Magic/Summon Damage\n+10 Magic/Summon Defense\n+0.1 Speed\nFire Type: Lights up area\nGround Type: Nullifies Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("CameruptMega").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCameruptMega = true;
				modPlayer.buffFireType = true;
				modPlayer.buffGroundType = true;
			}
			if (!modPlayer.summonedCameruptMega || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFireType = false;
				modPlayer.buffGroundType = false;
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
				player.statDefense += 10;
			}
			
			player.statLifeMax2 += 70;
			player.GetDamage(DamageClass.Melee) *= 1.24f;
			player.GetDamage(DamageClass.Ranged) *= 1.24f;
			player.GetDamage(DamageClass.Magic) *= 1.29f;
			player.GetDamage(DamageClass.Summon) *= 1.29f;
			player.maxRunSpeed += 0.1f;
			
			//modPlayer.numSpawned++;
		}
	}
}