using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffWobbuffet : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Wobbuffet!");
			Description.SetDefault("+190 HP\n+6% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+6% Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.2 Speed\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Wobbuffet").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedWobbuffet = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedWobbuffet || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPsychicType = false;
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
			
			player.statLifeMax2 += 190;
			player.GetDamage(DamageClass.Melee) *= 1.06f;
			player.GetDamage(DamageClass.Ranged) *= 1.06f;
			player.GetDamage(DamageClass.Magic) *= 1.06f;
			player.GetDamage(DamageClass.Summon) *= 1.06f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}