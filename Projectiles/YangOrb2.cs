using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace TaoMod.Projectiles
{
	public class YangOrb2 : ModProjectile
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
			projectile.timeLeft = 10000;
            projectile.tileCollide = false;
		}
		float distance = 128f;
		private float moveRotation = 0f;
		public override void AI(){
			Player player = Main.player[projectile.owner];
			projectile.Center = player.Center + new Vector2(distance, 0).RotatedBy(moveRotation);
			moveRotation = 8f;
		}
	}
}