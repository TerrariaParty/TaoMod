using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TaoMod.Dusts;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.Projectiles
{
	public class LightTrail : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Light Trail");
		}

		public override void SetDefaults()
		{
			projectile.width = 32;
			projectile.height = 32;
			projectile.aiStyle = -1;
			projectile.hostile = true;
            projectile.alpha = 255;
			if(Main.expertMode){
				projectile.timeLeft = 240;
			}
			else{
			projectile.timeLeft = 120;
			}
		}
        public override void AI(){
			if(projectile.timeLeft <= 0){
				projectile.Kill();
			}
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustType<LightDust>(), 0, 0);
            Lighting.AddLight(projectile.Center, 1f, 1f, 1f); // R G B values from 0 to 1f. This is the red from the Crimson Heart pet
        }
	}
}