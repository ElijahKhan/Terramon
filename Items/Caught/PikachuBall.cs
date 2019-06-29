using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Terramon.Items.Caught
{
	public class PikachuBall : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pokéball (Pikachu)");
			Tooltip.SetDefault("Use to send out [c/E5E500:Pikachu!]"
				+ "\n[c/B76FB7:Tier One]");
			DisplayName.AddTranslation(GameCulture.Chinese, "精灵球 (皮卡丘)");
			Tooltip.AddTranslation(GameCulture.Chinese, "用于派出[c/E5E500:皮卡丘!]"
				+ "\n[c/B76FB7:一级]");
		}

		public override void SetDefaults()
		{
			item.damage = 0;
			item.useStyle = 1;
			item.shoot = mod.ProjectileType("PikachuPet");
			item.width = 24;
			item.height = 24;
			item.UseSound = SoundID.Item2;
			item.useAnimation = 20;
			item.useTime = 20;
			item.rare = 8;
			item.noMelee = true;
			item.buffType = mod.BuffType("PikachuBuff");
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