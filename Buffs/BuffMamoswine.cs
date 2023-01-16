using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMamoswine : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Mamoswine!");
			Description.SetDefault("+110 HP\n+26% Melee/Ranged Damage\n+8 Melee/Ranged Defense\n+14% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.4 Speed\nIce Type: Unimplemented Effect\nGround Type: Nullifies Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Mamoswine").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMamoswine = true;
				modPlayer.buffIceType = true;
				modPlayer.buffGroundType = true;
			}
			if (!modPlayer.summonedMamoswine || modPlayer.pokemonAmount > 1) {
				modPlayer.buffIceType = false;
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
				player.statDefense += 8;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 110;
			player.GetDamage(DamageClass.Melee) *= 1.26f;
			player.GetDamage(DamageClass.Ranged) *= 1.26f;
			player.GetDamage(DamageClass.Magic) *= 1.14f;
			player.GetDamage(DamageClass.Summon) *= 1.14f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}