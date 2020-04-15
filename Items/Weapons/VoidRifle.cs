using TaoMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.Items.Weapons
{
	public class VoidRifle : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("The precision of a sniper, the brute force of a titan\n50% chance not to consume ammo\nReplaces Musket Balls with High Velocity Bullets");
		}

		public override void SetDefaults() {
			item.damage = 755;
            item.crit = 56;
			item.ranged = true;
			item.width = 72;
			item.height = 24;
			item.useTime = 50;
			item.useAnimation = 50;
			item.useStyle = 5;
			item.noMelee = true; 
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 11;
			item.UseSound = SoundID.Item40;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 20f;
			item.useAmmo = AmmoID.Bullet;
		}
		public override bool ConsumeAmmo(Player player)
		{
			return Main.rand.NextFloat() >= .5f;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			if (type == ProjectileID.Bullet) 
			{
				type = ProjectileID.BulletHighVelocity; 
			}
			Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
			return true;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-10, 0);
		}
	}
}