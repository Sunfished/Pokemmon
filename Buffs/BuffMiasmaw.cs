using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffMiasmaw : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Miasmaw!");
			Description.SetDefault("+85 HP\n+27% Melee/Ranged Damage\n+6 Melee/Ranged Defense\n+23% Magic/Summon Damage\n+8 Magic/Summon Defense\n+0.5 Speed\nBug Type: Unimplemented Effect\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Miasmaw").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedMiasmaw = true;
				modPlayer.buffBugType = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedMiasmaw || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
				modPlayer.buffDragonType = false;
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
				player.statDefense += 6;
			}
			else
			{
				player.statDefense += 8;
			}
			
			player.statLifeMax2 += 85;
			player.GetDamage(DamageClass.Melee) *= 1.27f;
			player.GetDamage(DamageClass.Ranged) *= 1.27f;
			player.GetDamage(DamageClass.Magic) *= 1.23f;
			player.GetDamage(DamageClass.Summon) *= 1.23f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}