using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Terramon.Items.Pokeballs
{
	public class UltraBall : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ultra Ball");
			Tooltip.SetDefault("It's an ultra-performance Ball."
				+ "\nProvides a higher Pokémon catch rate than a Great Ball.");
			DisplayName.AddTranslation(GameCulture.Chinese, "高级球");
			Tooltip.AddTranslation(GameCulture.Chinese, "性能非常不错的球."
				+ "\n比超级球更容易捉到宝可梦.");
		}
		public override void SetDefaults()
		{
			item.damage = 30;
			item.ranged = true;
			item.width = 34;
			item.height = 34;
			item.scale = 0.6f;
			item.maxStack = 30;
			item.consumable = true;
			item.useTime = 16;
			item.useAnimation = 16;
			item.useStyle = 1;
			item.knockBack = 0;
			item.value = 200000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.noUseGraphic = true;
			item.shootSpeed = 13f;
			item.shoot = mod.ProjectileType<Projectiles.UltraBallProjectile>();
		}
	}
}
