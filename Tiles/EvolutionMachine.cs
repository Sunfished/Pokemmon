using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Pokemmon.Tiles
{
	public class EvolutionMachine : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileBlockLight[Type] = false;
			Main.tileLighted[Type] = true;
			
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 16 , 18};
			TileObjectData.newTile.Width = 4;
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.addTile(Type);
			
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Evolution Machine");
			AddMapEntry(new Color(200, 200, 200), name);
			
			disableSmartCursor = true;
			//adjTiles = new int[] { TileID.WorkBenches };
		}
		
		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("EvolutionMachine"));
		}
	}
}