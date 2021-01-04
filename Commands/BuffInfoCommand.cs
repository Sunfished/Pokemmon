using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Pokemmon.Commands
{
	public class BuffInfoCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.Chat;

		public override string Command
			=> "buffinfo";

		public override string Usage
			=> "/buffinfo";

		public override string Description
			=> "Display current Pokemmon Buffs";

		public override void Action(CommandCaller caller, string input, string[] args) {
			/*int player;
			for (player = 0; player < 255; player++) {
				mod.Logger.Info(player);
				if (Main.player[player].active && Main.player[player].name == args[0]) {
					break;
				}
			}
			if (player == 255) {
				throw new UsageException("Could not find player: " + args[0]);
			}//*/
			
			mod.Logger.Info("Displayed Buff Info");
			//var modPlayer = Main.player[player].GetModPlayer<MyPlayer>();
			Player player = Main.player[Main.myPlayer];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			/*string bAtk = modPlayer.boostAttack.ToString();
			string bDef = modPlayer.boostDefense.ToString();
			caller.Reply("Pokemmon Buffs: +" + bAtk + "x Atk / +" + bDef + "x Def");//*/
			
			/*string s = "";
			if(modPlayer.attackList.Count <= 0)
			{
				for(var i=0; i<modPlayer.attackList.Count ; i++)
				{
					s += modPlayer.attackList.get(i).ToString() +", ";
				}
			}
			else
				s = "No Current Buffs";
			caller.Reply(s);//*/
			return;
		}
	}
}
