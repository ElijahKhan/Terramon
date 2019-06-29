using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Terramon.NPCs.Wild
{
	public class Bulbasaur : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Bulbasaur");
			DisplayName.AddTranslation(GameCulture.Chinese, "妙蛙种子");
			Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Bunny];
		}

		public override void SetDefaults() {
			npc.width = 36;
			npc.height = 20;
			npc.damage = 10;
			npc.defense = 0;
			npc.lifeMax = 1;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = mod.GetLegacySoundSlot(SoundType.NPCHit, "Sounds/NPCHit/capturepokemon");
			npc.value = 60f;
			npc.knockBackResist = 0.5f;
			npc.aiStyle = 7;
			aiType = NPCID.Bunny;
			animationType = NPCID.Bunny;
		}
		
		public override bool? CanBeHitByItem(Player player, Item item)
		{
			return false;
		}
		
		private bool? CanBeHitByPlayer(Player player)
		{
			return false;
		}

        public override bool? CanBeHitByProjectile(Projectile projectile)
        {

            if (projectile.type == mod.ProjectileType("PokeballProjectile") && projectile.ai[1] == 1)
            {
                return true;
            }
			if (projectile.type == mod.ProjectileType("GreatBallProjectile") && projectile.ai[1] == 1)
            {
                return true;
            }
			if (projectile.type == mod.ProjectileType("UltraBallProjectile") && projectile.ai[1] == 1)
            {
                return true;
            }
            return false;
        }

        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            knockback = 0;
            crit = false;
            if(projectile.type == mod.ProjectileType("PokeballProjectile"))
            {
                if(projectile.ai[1] == 1)
                {
                    if (Main.rand.NextFloat() < .1190f)
                    {
                        projectile.ai[1] = 2;
                        crit = false;
                        damage = npc.lifeMax;
						Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 220, npc.velocity.X * -0.5f, npc.velocity.Y * -0.5f);
						Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 220, npc.velocity.X * -0.5f, npc.velocity.Y * -0.5f);
						Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 220, npc.velocity.X * -0.5f, npc.velocity.Y * -0.5f);
						Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 220, npc.velocity.X * -0.5f, npc.velocity.Y * -0.5f);
						Main.NewText("Bulbasaur was caught!", 255, 178, 102);
                    }
                    else
                    {
                        Main.NewText("Miss...", Color.White);
                        damage = 0;
                        npc.life = npc.lifeMax+1;
                        projectile.ai[1] = 0;
                    }

                }
            }
    else if(projectile.type == mod.ProjectileType("GreatBallProjectile"))
            {
                if(projectile.ai[1] == 1)
                {
                    if (Main.rand.NextFloat() < .1785f)
                    {
                        projectile.ai[1] = 2;
                        crit = false;
                        damage = npc.lifeMax;
						Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 220, npc.velocity.X * -0.5f, npc.velocity.Y * -0.5f);
						Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 220, npc.velocity.X * -0.5f, npc.velocity.Y * -0.5f);
						Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 220, npc.velocity.X * -0.5f, npc.velocity.Y * -0.5f);
						Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 220, npc.velocity.X * -0.5f, npc.velocity.Y * -0.5f);
						Main.NewText("Bulbasaur was caught!", 255, 178, 102);
                    }
                    else
                    {
                        Main.NewText("Miss...", Color.White);
                        damage = 0;
                        npc.life = npc.lifeMax+1;
                        projectile.ai[1] = 0;
                    }

                }
            }
            else if(projectile.type == mod.ProjectileType("UltraBallProjectile"))
            {
                if(projectile.ai[1] == 1)
                {
                    if (Main.rand.NextFloat() < .2380f)
                    {
                        projectile.ai[1] = 2;
                        crit = false;
                        damage = npc.lifeMax;
						Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 220, npc.velocity.X * -0.5f, npc.velocity.Y * -0.5f);
						Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 220, npc.velocity.X * -0.5f, npc.velocity.Y * -0.5f);
						Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 220, npc.velocity.X * -0.5f, npc.velocity.Y * -0.5f);
						Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 220, npc.velocity.X * -0.5f, npc.velocity.Y * -0.5f);
						Main.NewText("Bulbasaur was caught!", 255, 178, 102);
                    }
                    else
                    {
                        Main.NewText("Miss...", Color.White);
                        damage = 0;
                        npc.life = npc.lifeMax+1;
                        projectile.ai[1] = 0;
                    }

                }
            }
			else
            {
                damage = 0;
            }
        }

        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {

        }
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo) 
		{
			if (spawnInfo.player.ZoneOverworldHeight)
			{
				return 0.1f;
			}
			else
			{
			return 0f;
			}
		}

        public override void NPCLoot()
        {
			Item.NewItem(npc.getRect(), mod.ItemType("BulbasaurBall"));
        }
	}
}