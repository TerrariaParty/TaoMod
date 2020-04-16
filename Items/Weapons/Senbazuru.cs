using TaoMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.Items.Weapons
{
	public class Senbazuru : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("You shall not know the truth until you have reached 1000 folds\nOnly usable if it is in a stack of 1000");
		}

		public override void SetDefaults()
		{
			item.damage = 32;
			item.crit = 6;
			item.thrown = true;
			item.width = 72;
			item.height = 24;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.knockBack = 4;
			item.value = 10;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ProjectileType<SenbazuruProjectile>(); //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 20f;
			item.maxStack = 1000;
		}
		public override bool CanUseItem(Player player)
		{
			return item.stack == 1000 && player.ownedProjectileCounts[item.shoot] < 10;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 7;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30)); // 30 degree spread.
																												// If you want to randomize the speed to stagger the projectiles
				float scale = 1f - (Main.rand.NextFloat() * .3f);
				perturbedSpeed = perturbedSpeed * scale; 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false; // return false because we don't want tmodloader to shoot projectile
		}
	}
}