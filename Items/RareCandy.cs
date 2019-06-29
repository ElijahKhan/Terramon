using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Terramon.Items
{
	public class RareCandy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rare Candy");
			Tooltip.SetDefault("A candy that is packed with energy."
				+ "\nThey can be used to level up [c/FFFF66:Pokémon.]");
			DisplayName.AddTranslation(GameCulture.Chinese, "神奇糖果");
			Tooltip.AddTranslation(GameCulture.Chinese, "充满能量的糖果."
				+ "\n可用于升级[c/FFFF66:宝可梦.]");
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
