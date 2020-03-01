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
	public class VoidHammerProjectileAlt : ModProjectile
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
            projectile.velocity.Y += projectile.ai[0];
        }
	}
}