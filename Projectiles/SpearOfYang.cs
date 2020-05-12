using Terraria.ID;
using Terraria.ModLoader;

namespace TaoMod.Projectiles
{
    public class SpearOfYang : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 24;
            projectile.height = 24;
            projectile.aiStyle = ProjectileID.WoodenArrowFriendly;
            projectile.friendly = true;
            projectile.penetrate = 2;
            projectile.alpha = 50;
            projectile.scale = 0.8f;
            projectile.tileCollide = false;
            projectile.ranged = true;
            projectile.tileCollide = true;
        }
    }
}
