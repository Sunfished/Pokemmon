using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Pokemmon.Buffs
{
	public class BuffBurmyTrashCloak : ModBuff
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Go, Burmy!");
			Description.SetDefault("+40 HP\n+5% Melee/Ranged Damage\n+4 Melee/Ranged Defense\n+5% Magic/Summon Damage\n+4 Magic/Summon Defense\n+0.2 Speed\nBug Type: Unimplemented Effect");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.ownedProjectileCounts[Mod.Find<ModProjectile>("BurmyTrashCloak").Type] > 0 && modPlayer.pokemonAmount == 1) {
				player.buffTime[buffIndex] = 18000;
				modPlayer.summonedBurmyTrashCloak = true;
				modPlayer.buffBugType = true;
			}
			if (!modPlayer.summonedBurmyTrashCloak || modPlayer.pokemonAmount > 1) {
				modPlayer.buffBugType = false;
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
				player.statDefense += 4;
			}
			else
			{
				player.statDefense += 4;
			}
			
			player.statLifeMax2 += 40;
			player.GetDamage(DamageClass.Melee) *= 1.05f;
			player.GetDamage(DamageClass.Ranged) *= 1.05f;
			player.GetDamage(DamageClass.Magic) *= 1.05f;
			player.GetDamage(DamageClass.Summon) *= 1.05f;
			player.maxRunSpeed += 0.2f;
			
			//modPlayer.numSpawned++;
		}
	}
}