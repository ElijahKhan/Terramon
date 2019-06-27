using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terramon.Projectiles.PKMN
{
	public class PikachuPet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pikachu");
			Main.projFrames[projectile.type] = 8;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bunny);
			aiType = ProjectileID.Bunny;
			drawOriginOffsetY = -14;
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
				modPlayer.pikachuPet = false;
			}
			if (modPlayer.pikachuPet)
			{
				projectile.timeLeft = 2;
			}
		}
	}
}