using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffMimeJr : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Mime Jr.!");
			Description.SetDefault("+20 HP\n+1.0x Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+1.2x Magic/Summon Damage\n+9 Magic/Summon Defense\n+0.3 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("MimeJr")] > 0) {
				modPlayer.summonedMimeJr = true;
			}
			if (!modPlayer.summonedMimeJr) {
				player.DelBuff(buffIndex);
				buffIndex--;
				
			}
			else {
				player.buffTime[buffIndex] = 18000;
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
				player.statDefense += 9;
			}
			
			player.statLifeMax2 += 20;
			player.meleeDamage *= 1.0f;
			player.rangedDamage *= 1.0f;
			player.magicDamage *= 1.2f;
			player.minionDamage *= 1.2f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}