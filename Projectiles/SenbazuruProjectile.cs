using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TaoMod.Projectiles
{
	public class SenbazuruProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			projectile.thrown = true;
			projectile.width = 52;
			projectile.height = 42;
			projectile.aiStyle = 1;
			projectile.ignoreWater = false;
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.timeLeft = 10000;
			projectile.penetrate = -1;
			projectile.scale = 0.75f;
		}
		private bool BouncedOnce;
		private int StopFuckingMovingBitch = 0;
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (BouncedOnce == false)
			{
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				BouncedOnce = true;
			}
			if(BouncedOnce == true)
			{
				StopFuckingMovingBitch++;
			}
			if (BouncedOnce == true && StopFuckingMovingBitch > 4)
			{
				projectile.velocity = Vector2.Zero;
				projectile.timeLeft = 600;
			}
			return false;
		}
		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation();
		}
	}
}