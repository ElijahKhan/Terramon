using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terramon.Projectiles.PKMN
{
	public class BulbasaurPet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bulbasaur");
			Main.projFrames[projectile.type] = 8;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bunny);
			aiType = ProjectileID.Bunny;
			drawOriginOffsetY = -20;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			player.bunny = false;
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			TerramonPlayer modPlayer = player.GetModPlayer<TerramonPlayer>(mod);
			if (player.dead)
			{
				modPlayer.bulbasaurPet = false;
			}
			if (modPlayer.bulbasaurPet)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}