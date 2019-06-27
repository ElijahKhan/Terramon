using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Terramon.Commands
{
    class PokedexCommand : ModCommand
    {
        public override CommandType Type
		{
			get { return CommandType.Chat; }
		}

        public override string Command
		{
			get { return "pokedex"; }
		}
		
        public override string Description
		{
			get { return "Used for finding Pokémon data."; }
		}
		
		public override string Usage
		{
			get { return "/pokedex [pokemon name (lowercase)]"; }
		}

        public override void Action(CommandCaller caller, string input, string[] args)
        {
			if(Main.LocalPlayer.HasItem(mod.ItemType("Pokedex")))
			{
				if (args.Length == 0)
				{
                caller.Reply("Incorrect Usage: /pokedex [pokemon name (lowercase)]");
                return;
				}
				if (args[0].ToLower() == "pikachu")
				{
				Main.NewText("Pikachu.", Color.White);
				}
				if (args[0].ToLower() == "rhyhorn")
				{
				Main.NewText("Rhyhorn.", Color.White);
				}
			}
			else
			{
				Main.NewText("This command can't be used as you don't have the [c/FF3333:Pokédex] in your inventory!", 135, 206, 250);
			}
        }
    }
}
