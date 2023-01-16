using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffGroudon : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Groudon!");
			Description.SetDefault("+100 HP\n+30% Melee/Ranged Damage\n+14 Melee/Ranged Defense\n+20% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.5 Speed\nGround Type: Nullifies Knockback");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Groudon").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedGroudon = true;
				modPlayer.buffGroundType = true;
			}
			if (!modPlayer.summonedGroudon || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 14;
			}
			else
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 100;
			player.GetDamage(DamageClass.Melee) *= 1.3f;
			player.GetDamage(DamageClass.Ranged) *= 1.3f;
			player.GetDamage(DamageClass.Magic) *= 1.2f;
			player.GetDamage(DamageClass.Summon) *= 1.2f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}