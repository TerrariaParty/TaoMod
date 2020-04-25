using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TaoMod.Projectiles.Cards;
using static Terraria.ModLoader.ModContent;
using TaoMod.PartialPlayerClasses;

namespace TaoMod.Items.Weapons
{
    class TheGamblersFullDeck : ModItem
    {
        public int cardtossCost = 1;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Gambler's Full Deck");
            Tooltip.SetDefault("'The fortunate gambler's very own set'\nLeft click to throw out a single, random card from the deck\nRight click to unleash all the cards at once\nYou can only have 10 cards at once");
        }
        public override void SetDefaults()
        {
            item.height = 10;
            item.width = 10;
            item.useStyle = 1;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useAnimation = 15;
            item.useTime = 15;
            item.thrown = true;
            item.crit = 0;
            item.damage = 75;
            item.rare = 5;
            item.shootSpeed = 10f;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.knockBack = 2f;
            item.shoot = 10;
        }
        public Color blue = new Color(0, 0, 255);
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            var taoPlayer = player.GetModPlayer<TaoPlayer>();
            if (player.altFunctionUse == 2)
            {
                item.useStyle = 1;
                item.useTime = 35;
                item.useAnimation = 35;
                item.damage = 50;
                item.shoot = 10;
            }
            else
            {
                if (taoPlayer.cardsCurrent >= cardtossCost)
                {
                    taoPlayer.cardsCurrent -= 1;
                    return true;
                }
                item.useStyle = 1;
                item.useTime = 15;
                item.useAnimation = 15;
                item.damage = 50;
                item.shoot = 10;
            }
            if (taoPlayer.cardsCurrent == 0)
            {
                return false;
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            var taoPlayer = player.GetModPlayer<TaoPlayer>();
            if (player.altFunctionUse == 2)
            {
                CombatText.NewText(player.getRect(), blue, "Oops! That's All My Deck", true);
                int numberProjectiles = taoPlayer.cardsCurrent;
                type = Main.rand.Next(new int[] { ProjectileType<SpadeCard>(), ProjectileType<HeartCard>(), ProjectileType<CrystalCard>(), ProjectileType<IchorCard>(), ProjectileType<CursedCard>() });
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(65)); // 30 degree spread.
                                                                                                                    // If you want to randomize the speed to stagger the projectiles
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                }

                taoPlayer.cardsCurrent -= taoPlayer.cardsCurrent;
                return false;
            }
            else {
                type = Main.rand.Next(new int[] { ProjectileType<SpadeCard>(), ProjectileType<HeartCard>(), ProjectileType<CrystalCard>(), ProjectileType<IchorCard>(), ProjectileType<CursedCard>() });
                Projectile.NewProjectile(player.position, Main.MouseWorld, type, 50, 2f, Main.myPlayer);
                return true;
            }
        }
    }
}
