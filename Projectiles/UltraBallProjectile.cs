using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Achievements;

namespace Terramon.Projectiles
{
	class UltraBallProjectile : ModProjectile
	{

        bool collide = true;
		public override void SetDefaults()
		{
			projectile.width = 9;
			projectile.height = 10;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.damage = 30;
			projectile.timeLeft = 300;
            collide = true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.ai[1] == 2)
			{
				return true;
			}
			// OnTileCollide can trigger quite quickly, so using soundDelay helps prevent the sound from overlapping too much.
			if (projectile.soundDelay == 0)
			{
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/ballbounce").WithVolume(.7f));
			}
			projectile.soundDelay = 10;

			// This code makes the projectile very bouncy.
			if (projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
			{
				projectile.velocity.X = oldVelocity.X * -0.4f;
			}
			if (projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
			{
				projectile.velocity.Y = oldVelocity.Y * -0.4f;
			}
			return false;
		}

		public override void AI()
		{
			if (projectile.ai[0] == 0)
                {
					Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/throwball").WithVolume(.7f));
					projectile.ai[0] = 1;
                    projectile.ai[1] = 1;

                    projectile.netUpdate = true;
				}
					
			if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
			{
				Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 0, default(Color), 1f);
				projectile.tileCollide = false;
				// Set to transparent. This projectile technically lives as  transparent for about 3 frames
				projectile.alpha = 255;
				// change the hitbox size, centered about the original projectile center. This makes the projectile damage enemies during the explosion.
				projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
				projectile.width = 250;
				projectile.height = 250;
				projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
				projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
			}
			else
			{
				// Smoke and fuse dust spawn.
				if (Main.rand.Next(3) == 0)
				{
					int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 15, 0f, 0f, 100, default(Color), 0.5f);
					Main.dust[dustIndex].scale = 0.1f + (float)Main.rand.Next(5) * 0.1f;
					Main.dust[dustIndex].fadeIn = 1.5f + (float)Main.rand.Next(5) * 0.1f;
					Main.dust[dustIndex].noGravity = true;
					Main.dust[dustIndex].position = projectile.Center + new Vector2(0f, (float)(-(float)projectile.height / 2)).RotatedBy((double)projectile.rotation, default(Vector2)) * 1.1f;
				}
			}
			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 5f)
			{
				projectile.ai[0] = 10f;
				// Roll speed dampening.
				if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
				{
					projectile.velocity.X = projectile.velocity.X * 0.97f;
					//if (projectile.type == 29 || projectile.type == 470 || projectile.type == 637)
					{
						projectile.velocity.X = projectile.velocity.X * 0.99f;
					}
					if ((double)projectile.velocity.X > -0.01 && (double)projectile.velocity.X < 0.01)
					{
						projectile.velocity.X = 0f;
						projectile.netUpdate = true;
					}
				}
				projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			}
			// Rotation increased by velocity.X 
			projectile.rotation += projectile.velocity.X * 0.1f;
			return;
		}
		
		public override void Kill(int timeLeft)
        {
            Main.PlaySound(SoundID.Item10, projectile.position);
			Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64);
			Vector2 usePos = projectile.position; 
												  
			Vector2 rotVector =
				(projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
			usePos += rotVector * 16f;

			for (int i = 0; i < 20; i++) {
				Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 64);
				dust.position = (dust.position + projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
				usePos -= rotVector * 8f;
			}
        }
	}
}