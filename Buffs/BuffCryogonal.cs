using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffCryogonal : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Cryogonal!");
			Description.SetDefault("+80 HP\n+10% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+19% Magic/Summon Damage\n+13 Magic/Summon Defense\n+0.5 Speed\nIce Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Cryogonal")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedCryogonal = true;
				modPlayer.buffIceType = true;
			}
			if (!modPlayer.summonedCryogonal || modPlayer.pokemonAmount > 1) {
				modPlayer.buffIceType = false;
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
				player.statDefense += 5;
			}
			else
			{
				player.statDefense += 13;
			}
			
			player.statLifeMax2 += 80;
			player.meleeDamage *= 1.1f;
			player.rangedDamage *= 1.1f;
			player.magicDamage *= 1.19f;
			player.minionDamage *= 1.19f;
			player.maxRunSpeed += 0.5f;
			
			//modPlayer.numSpawned++;
		}
	}
}