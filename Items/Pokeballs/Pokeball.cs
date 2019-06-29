using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Terramon.Items.Pokeballs
{
	public class Pokeball : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pokéball");
			Tooltip.SetDefault("A device for catching wild Pokémon."
				+ "\nIt is thrown like a ball at the target."
					+ "\nIt is designed as a capsule system.");
			DisplayName.AddTranslation(GameCulture.Chinese, "精灵球");
			Tooltip.AddTranslation(GameCulture.Chinese, "捕捉野生宝可梦的道具."
				+ "\n用于投向野生宝可梦并将其捕捉的球."
					+"它是胶囊样式的.");
		}
		public override void SetDefaults()
		{
			item.damage = 10;
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
			item.value = 10000;
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.noUseGraphic = true;
			item.shootSpeed = 12f;
			item.shoot = mod.ProjectileType<Projectiles.PokeballProjectile>();
		}
	}
}
