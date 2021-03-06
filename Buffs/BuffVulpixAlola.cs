using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffVulpixAlola : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Vulpix!");
			Description.SetDefault("+38 HP\n+8% Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+10% Magic/Summon Damage\n+6 Magic/Summon Defense\n+0.3 Speed\nIce Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("VulpixAlola")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedVulpixAlola = true;
				modPlayer.buffIceType = true;
			}
			if (!modPlayer.summonedVulpixAlola || modPlayer.pokemonAmount > 1) {
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
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 6;
			}
			
			player.statLifeMax2 += 38;
			player.meleeDamage *= 1.08f;
			player.rangedDamage *= 1.08f;
			player.magicDamage *= 1.1f;
			player.minionDamage *= 1.1f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}