using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace Terramon
{
	public class TerramonPlayer : ModPlayer
	{
		public static bool starterNotChosen = true; // Has the starter been chosen yet?
		public bool pikachuPet = false; // Pokemon #25
		public bool bulbasaurPet = false; // Pokemon #1
	
		public override void ResetEffects()
		{
			pikachuPet = false;
			bulbasaurPet = false;
		}
		
		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath) 
		{
			Item item = new Item();
			item.SetDefaults(mod.ItemType("Pokeball"));
			item.stack = 5;
			items.Add(item);
			item = new Item();
			item.SetDefaults(mod.ItemType("Pokedex"));
			item.stack = 1;
			items.Add(item);
		}
	}
}