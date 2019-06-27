using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Achievements;

namespace Terramon
{
	class Terramon : Mod
	{
		public Terramon()
		{
	
		}
		
		public override void Load()
			{
				Main.music[MusicID.OverworldDay] = GetMusic("Sounds/Music/overworldnew");
				Main.music[MusicID.Night] = GetMusic("Sounds/Music/nighttime");
				Main.music[MusicID.AltOverworldDay] = GetMusic("Sounds/Music/overworldnew");				// Main.music[MusicID.Eerie] is the default music played in the biome and GetMusic("Sounds/Music/CustomMusic"); is the replace song
			}
	}
}
