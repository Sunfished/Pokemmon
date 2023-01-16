using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffSolotl : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Solotl!");
			Description.SetDefault("+68 HP\n+9% Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+14% Magic/Summon Damage\n+2 Magic/Summon Defense\n+0.4 Speed\nFire Type: Lights up area\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Solotl").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedSolotl = true;
				modPlayer.buffFireType = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedSolotl || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFireType = false;
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
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 2;
			}
			
			player.statLifeMax2 += 68;
			player.GetDamage(DamageClass.Melee) *= 1.09f;
			player.GetDamage(DamageClass.Ranged) *= 1.09f;
			player.GetDamage(DamageClass.Magic) *= 1.14f;
			player.GetDamage(DamageClass.Summon) *= 1.14f;
			player.maxRunSpeed += 0.4f;
			
			//modPlayer.numSpawned++;
		}
	}
}