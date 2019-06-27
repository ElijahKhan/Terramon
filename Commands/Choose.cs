﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Terramon.Commands
{
    class Choose : ModCommand
    {
        public override CommandType Type
		{
			get { return CommandType.Chat; }
		}

        public override string Command
		{
			get { return "choose"; }
		}
		
        public override string Description
		{
			get { return "Pick your starter Pokémon."; }
		}
		
		public override string Usage
		{
			get { return "/choose [bulbasaur, squirtle, charmander"; }
		}

        public override void Action(CommandCaller caller, string input, string[] args)
        {
			if (TerramonPlayer.starterNotChosen)
			{
				if (args.Length == 0)
				{
					caller.Reply("Ready to pick your Starter Pokémon? There are three options to choose from; [c/33FF33:Bulbasaur,] [c/00FFFF:Squirtle,] and [c/FF8C00:Charmander.]");
					caller.Reply("[c/C0C0C0:/choose (bulbasaur | squirtle | charmander)]");
					return;
				}
				if (args[0].ToLower() == "bulbasaur")
				{
					Main.NewText("You chose [c/33FF33:Bulbasaur, the Seed Pokémon.] Great choice!");
					TerramonPlayer.starterNotChosen = false;
					Item.NewItem(Main.LocalPlayer.getRect(), mod.ItemType("BulbasaurBall"));
				}
				if (args[0].ToLower() == "squirtle")
				{
					Main.NewText("You chose [c/00FFFF:Squirtle, the Tiny Turtle Pokémon.] Great choice!");
					TerramonPlayer.starterNotChosen = false;
				}
				if (args[0].ToLower() == "charmander")
				{
					Main.NewText("You chose [c/FF8C00:Charmander, the Fire Lizard Pokémon.] Great choice!");
					TerramonPlayer.starterNotChosen = false;
				}
			}
			else
			{
				Main.NewText("[c/FFA500:You've already chosen your Starter Pokémon!]");
			}
        }
    }
}
