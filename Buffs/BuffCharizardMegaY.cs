using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCharizardMegaY : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Charizard!");
			Description.SetDefault("+78 HP\n+20% Melee/Ranged Damage\n+7 Melee/Ranged Defense\n+30% Magic/Summon Damage\n+11 Magic/Summon Defense\n+0.5 Speed\nFire Type: Lights up area\nFlying Type: Descends slowly in the air");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("CharizardMegaY")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCharizardMegaY = true;
				modPlayer.buffFireType = true;
				modPlayer.buffFlyingType = true;
			}
			if (!modPlayer.summonedCharizardMegaY || modPlayer.pokemonAmount > 1) {
				modPlayer.buffFireType = false;
				modPlayer.buffFlyingType = false;
				player.DelBuff(buffIndex);
				buffIndex--;
				modPlayer.pokemonAmount = 0;
			}
		
			//Calc Buffs
			var isMelee = true;
			if(player.magicDamage > player.meleeDamage || player.magicDamage > player.rangedDamage ||
			player.minionDamage > player.meleeDamage || player.minionDamage > player.rangedDamage)
				isMelee = false;
			if (isMelee)
			{
				player.statDefense += 7;
			}
			else
			{
				player.statDefense += 11;
			}
			
			player.statLifeMax2 += 78;
			player.meleeDamage *= 1.2f;
			player.rangedDamage *= 1.2f;
			player.magicDamage *= 1.3f;
			player.minionDamage *= 1.3f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}