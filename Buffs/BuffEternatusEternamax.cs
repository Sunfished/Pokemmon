using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffEternatusEternamax : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Eternatus!");
			Description.SetDefault("+255 HP\n+23% Melee/Ranged Damage\n+25 Melee/Ranged Defense\n+25% Magic/Summon Damage\n+25 Magic/Summon Defense\n+0.7 Speed\nPoison Type: Unimplemented Effect\nDragon Type: Multitude of effects when HP < 20%");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("EternatusEternamax").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedEternatusEternamax = true;
				modPlayer.buffPoisonType = true;
				modPlayer.buffDragonType = true;
			}
			if (!modPlayer.summonedEternatusEternamax || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPoisonType = false;
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
				player.statDefense += 25;
			}
			else
			{
				player.statDefense += 25;
			}
			
			player.statLifeMax2 += 255;
			player.GetDamage(DamageClass.Melee) *= 1.23f;
			player.GetDamage(DamageClass.Ranged) *= 1.23f;
			player.GetDamage(DamageClass.Magic) *= 1.25f;
			player.GetDamage(DamageClass.Summon) *= 1.25f;
			player.maxRunSpeed += 0.7f;
			
			//modPlayer.numSpawned++;
		}
	}
}