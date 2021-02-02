using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffEternatusEternamax : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Eternatus!");
			Description.SetDefault("+255 HP\n+1.3x Melee/Ranged Damage\n+25 Melee/Ranged Defense\n+1.4x Magic/Summon Damage\n+25 Magic/Summon Defense\n+0.7 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("EternatusEternamax")] > 0) {
				modPlayer.summonedEternatusEternamax = true;
			}
			if (!modPlayer.summonedEternatusEternamax) {
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
				player.statDefense += 25;
			}
			else
			{
				player.statDefense += 25;
			}
			
			player.statLifeMax2 += 255;
			player.meleeDamage *= 1.3f;
			player.rangedDamage *= 1.3f;
			player.magicDamage *= 1.4f;
			player.minionDamage *= 1.4f;
			player.maxRunSpeed += 0.7f;
			
			//modPlayer.numSpawned++;
		}
	}
}