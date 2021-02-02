using Terraria;
using Terraria.ModLoader;

namespace Pokemmon.Buffs
{
	public class BuffQuilladin : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Go, Quilladin!");
			Description.SetDefault("+61 HP\n+1.2x Melee/Ranged Damage\n+9 Melee/Ranged Defense\n+1.1x Magic/Summon Damage\n+5 Magic/Summon Defense\n+0.3 Speed");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("Quilladin")] > 0) {
				modPlayer.summonedQuilladin = true;
			}
			if (!modPlayer.summonedQuilladin) {
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
				player.statDefense += 9;
			}
			else
			{
				player.statDefense += 5;
			}
			
			player.statLifeMax2 += 61;
			player.meleeDamage *= 1.2f;
			player.rangedDamage *= 1.2f;
			player.magicDamage *= 1.1f;
			player.minionDamage *= 1.1f;
			player.maxRunSpeed += 0.3f;
			
			//modPlayer.numSpawned++;
		}
	}
}