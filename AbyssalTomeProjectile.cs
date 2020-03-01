using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VoidEncounter.Items.Projectiles
{
	public class AbyssalTomeProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 15;
			DisplayName.SetDefault("Pentagram");
		}

		public override void SetDefaults()
		{
			projectile.scale = 1f;
			projectile.extraUpdates = 0;
			projectile.width = 142;
			projectile.height = 142;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.magic = true;
			projectile.timeLeft = 300;
		}
        public override void Kill(int timeLeft) {
        }
        public override void AI()
		{
			projectile.Center = Main.MouseWorld;
			projectile.velocity = Vector2.Zero;
			projectile.rotation += 0.01f;

			if (projectile.frame == 14)
				return;
			projectile.frameCounter++;
			int FramesToWait = 1;
			if (projectile.frameCounter >= FramesToWait)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
			}
		}
	}
}