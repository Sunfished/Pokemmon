using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffPichuSpikyEared : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Pichu!");
			Description.SetDefault("+20 HP\n+8% Melee/Ranged Damage\n+1 Melee/Ranged Defense\n+7% Magic/Summon Damage\n+3 Magic/Summon Defense\n+0.3 Speed\nElectric Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("PichuSpikyEared")] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedPichuSpikyEared = true;
				modPlayer.buffElectricType = true;
			}
			if (!modPlayer.summonedPichuSpikyEared || modPlayer.pokemonAmount > 1) {
				modPlayer.buffElectricType = false;
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
				player.statDefense += 1;
			}
			else
			{
				player.statDefense += 3;
			}
			
			player.statLifeMax2 += 20;
			player.meleeDamage *= 1.08f;
			player.rangedDamage *= 1.08f;
			player.magicDamage *= 1.07f;
			player.minionDamage *= 1.07f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}