using Terraria;
using Terraria.ModLoader;

namespace TaoMod.Projectiles.Cards
{
	class HeartCard : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Heart Card");
			Main.projFrames[projectile.type] = 8;
		}
		public override void SetDefaults()
		{
			projectile.width = 28;
			projectile.height = 20;
			projectile.aiStyle = 0;
			projectile.friendly = true;
			projectile.timeLeft = 600;
			projectile.tileCollide = true;
			projectile.penetrate = 1;
		}
		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation();
			projectile.frameCounter++;
			if (projectile.frameCounter >= 9)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1);
			}
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			int amountToHeal = Main.rand.Next(1, 3); // Heal 1 - 3 damage.
			if (amountToHeal + player.statLife > player.statLifeMax2)
			{
				amountToHeal = player.statLifeMax2 - player.statLife; // If healing is larger than health currently missing.
			}
			player.statLife += amountToHeal;
			player.HealEffect(amountToHeal, true);
		}
	}
}
