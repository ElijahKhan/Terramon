using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terramon.Items
{
	public class RareCandy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rare Candy");
			Tooltip.SetDefault("A candy that is packed with energy."
				+ "\nThey can be used to level up [c/FFFF66:Pokémon.]");
		} 
		public override void SetDefaults()
		{
			item.width = 42;
			item.height = 42;
			item.scale = 0.5f;
			item.maxStack = 999;
			item.value = 60000;
			item.rare = 9;
		}
	}
}
