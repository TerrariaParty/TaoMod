using Terraria;
using Terraria.ModLoader;

namespace TaoMod.Projectiles.Cards
{
	class CrystalCard : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystal Card");
			Main.projFrames[projectile.type] = 8;
		}
		public override void SetDefaults()
		{
			projectile.width = 28;
			projectile.height = 20;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.timeLeft = 600;
			projectile.tileCollide = false;
			projectile.maxPenetrate = 5;
		}
		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation();
			projectile.frameCounter++;
			if (projectile.frameCounter >= 9)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 3;
			}
		}
	}
}
