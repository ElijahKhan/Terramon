using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Terramon.Items.Caught
{
	public class BulbasaurBall : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pokéball (Bulbasaur)");
			Tooltip.SetDefault("Use to send out [c/33FF33:Bulbasaur!]"
				+ "\n[c/B76FB7:Tier One]");
			DisplayName.AddTranslation(GameCulture.Chinese, "精灵球 (妙蛙种子)");
			Tooltip.AddTranslation(GameCulture.Chinese, "用于派出[c/33FF33:妙蛙种子!]"
				+ "\n[c/B76FB7:一级]");
		}

		public override void SetDefaults()
		{
			item.damage = 0;
			item.useStyle = 1;
			item.shoot = mod.ProjectileType("BulbasaurPet");
			item.width = 24;
			item.height = 24;
			item.UseSound = SoundID.Item2;
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = 2;
			item.noMelee = true;
			item.buffType = mod.BuffType("BulbasaurBuff");
		}

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}