using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TaoMod.Dusts;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace TaoMod.Projectiles
{
	public class YangOrb : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yang Orb");
			ProjectileID.Sets.TrailingMode[projectile.type] = 0;
			ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
		}

		public override void SetDefaults()
		{
			if(Main.expertMode){
				projectile.damage = 35;
			}
			else{
				projectile.damage = 25;
			}
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = -1;
			projectile.hostile = true;
            projectile.alpha = 45;
			projectile.timeLeft = 920;
            projectile.tileCollide = false;
		}
		int speedUpTimer = 0;
        public override void AI(){
			speedUpTimer++;
			if(projectile.timeLeft <= 0){
				projectile.Kill();
			}
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<LightDust>(), 0, 0);
            Lighting.AddLight(projectile.Center, 1f, 1f, 1f); 
			if(speedUpTimer % 45 == 0){
				projectile.velocity.X *= 2;
				projectile.velocity.Y *= 2;
			}
        }
	}
}