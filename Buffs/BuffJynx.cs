using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffJynx : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Jynx!");
			Description.SetDefault("+65 HP\n+10% Melee/Ranged Damage\n+3 Melee/Ranged Defense\n+23% Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.5 Speed\nIce Type: Unimplemented Effect\nPsychic Type: Regens Mana faster");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Jynx")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedJynx = true;
				modPlayer.buffIceType = true;
				modPlayer.buffPsychicType = true;
			}
			if (!modPlayer.summonedJynx || modPlayer.pokemonAmount > 1) {
				modPlayer.buffIceType = false;
				modPlayer.buffPsychicType = false;
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
				player.statDefense += 3;
			}
			else
			{
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 65;
			player.meleeDamage *= 1.1f;
			player.rangedDamage *= 1.1f;
			player.magicDamage *= 1.23f;
			player.minionDamage *= 1.23f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}