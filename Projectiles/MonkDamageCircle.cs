using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TaoMod.Projectiles
{
    public class MonkDamageCircle : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 128;
            projectile.height = 128;
            projectile.alpha = 255;
            projectile.timeLeft = 120;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.penetrate = -1;
        }
        bool createDust = true;
        int dustTimer = 10;
        int i;

        public override void AI()
        {
            NPC monk = Main.npc[(int)projectile.ai[0]];
            dustTimer--;

            projectile.Center = monk.Center;
            if (!monk.active)
            {
                projectile.Kill();
            }

            if (dustTimer == 0)
            {
                if (createDust)
                {
                    if (i < 90)
                    {
                        Vector2 dustPos = projectile.Center + new Vector2(0, -40);
                        Dust dust = Dust.NewDustPerfect(dustPos, DustID.CrystalPulse);
                        dust.noGravity = true;

                        i++;
                    }
                    createDust = false;
                }
                else if (!createDust)
                {
                    createDust = true;
                }
                dustTimer = 10;
            }
        }

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            if (Main.hardMode)
            {
                projectile.width = 176;
                projectile.height = 176;
            }
        }
    }
}
