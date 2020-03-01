using Microsoft.Xna.Framework;
using Terraria;
using VoidEncounter;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Enums;
using Terraria.ModLoader;

namespace VoidEncounter.Items.Projectiles
{
	public class VoidHammerProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Hammer");
		}

		public override void SetDefaults() {
			projectile.CloneDefaults(ProjectileID.DeathSickle);
			aiType = ProjectileID.DeathSickle;
			projectile.magic = true;
		}

		public override bool PreKill(int timeLeft) {
			projectile.type = ProjectileID.DeathSickle;
			return true;
		}
		private float moveRotation = 0f;
        float distance = 120f;
	    float randomSpeed = Main.rand.NextFloat(2f);
	    float randomDistance = Main.rand.NextFloat(3f);
	    public override void AI(){
            Player player = Main.player[projectile.owner];
            projectile.Center = player.Center + new Vector2(distance, 0).RotatedBy(moveRotation);
            moveRotation += MathHelper.ToRadians((randomSpeed + 1f) * 6f);  
		    distance += randomDistance;	
        }
	}
}