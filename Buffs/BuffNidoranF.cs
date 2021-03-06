using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffNidoranF : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Nidoran-F!");
			Description.SetDefault("+55 HP\n+9% Melee/Ranged Damage\n+5 Melee/Ranged Defense\n+8% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.2 Speed\nPoison Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("NidoranF")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedNidoranF = true;
				modPlayer.buffPoisonType = true;
			}
			if (!modPlayer.summonedNidoranF || modPlayer.pokemonAmount > 1) {
				modPlayer.buffPoisonType = false;
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
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 55;
			player.meleeDamage *= 1.09f;
			player.rangedDamage *= 1.09f;
			player.magicDamage *= 1.08f;
			player.minionDamage *= 1.08f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}