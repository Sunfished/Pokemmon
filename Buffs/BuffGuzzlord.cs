using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffGuzzlord : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Guzzlord!");
			Description.SetDefault("+223 HP\n+20% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+19% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.2 Speed\nDark Type: Unimplemented Effect\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Guzzlord").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedGuzzlord = true;
				modPlayer.buffDarkType = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedGuzzlord || modPlayer.pokemonAmount > 1) {
				modPlayer.buffDarkType = false;
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 223;
			player.GetDamage(DamageClass.Melee) *= 1.2f;
			player.GetDamage(DamageClass.Ranged) *= 1.2f;
			player.GetDamage(DamageClass.Magic) *= 1.19f;
			player.GetDamage(DamageClass.Summon) *= 1.19f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}