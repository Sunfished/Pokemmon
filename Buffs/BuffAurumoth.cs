using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffAurumoth : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Aurumoth!");
			Description.SetDefault("+110 HP\n+24% Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+23% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.5 Speed\nBug Type: Unimplemented Effect\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("Aurumoth").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedAurumoth = true;
				modPlayer.buffBugType = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedAurumoth || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
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
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 110;
			player.GetDamage(DamageClass.Melee) *= 1.24f;
			player.GetDamage(DamageClass.Ranged) *= 1.24f;
			player.GetDamage(DamageClass.Magic) *= 1.23f;
			player.GetDamage(DamageClass.Summon) *= 1.23f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}