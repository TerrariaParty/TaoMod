using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TaoMod.Items.Rapiers
{
    //start of the rapier inheritance class

    /// <summary>
    /// Inherited class. Sets up the basics for a Rapier esc item.
    /// </summary>
    public abstract class RapierBase : ModItem
    {
        public override void SetDefaults()
        {
            //some defaults that cannot be changed
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.melee = true;

            base.SetDefaults();
        }

        /// <summary>
        /// Creates variables that set the customizable stats of the Rapier esc item.
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="crit"></param>
        /// <param name="knockback"></param>
        /// <param name="useSpeed"></param>
        /// <param name="rarity"></param>
        /// <param name="value"></param>
        /// <param name="autoReuse"></param>
        /// <param name="rapierProjectile"></param>
        /// <param name="rapierShootSpeed"></param>
        public virtual void RapierStats(int damage, int crit, float knockback, int useSpeed, int rarity, int value, bool autoReuse, int rapierProjectile, float rapierShootSpeed)
        {
            //sets the stats after variables are declared in the method body
            item.damage = damage;
            item.crit = crit;
            item.knockBack = knockback;
            item.useTime = useSpeed;
            item.useAnimation = useSpeed;
            item.rare = rarity;
            item.value = value;
            item.shoot = rapierProjectile;
            item.shootSpeed = rapierShootSpeed;
            item.autoReuse = autoReuse;
        }
        public override bool CanUseItem(Player player)
        {
            /*
                since rapiers are technically thrusted weapons like spears ill make it so  
                you can only attack while no rapiers are currently out, like a spear
                
                reminder: once 1.4 tml releases there will be no need to make it act as a spear
                          simply giving it the shortsword usestyle should be enough
            */
            return player.ownedProjectileCounts[item.shoot] < 1;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 1;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));    
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; 
        }
    }

    //i'll start the rapier projectile inhertied class here, since making another file is uh, wack
    //code taken from example mod cause i'm lazy 😎 
    //credit to examplemod, chicken bones, joifarden, blushiemagic, and javidpack (the contributors to this file specifically, ExampleSpearProjectile.cs
    //seems as if spearcode did not work 
    //credit to dayork for below code

    /// <summary>
    /// Inherited class. Sets up the basics for a Rapier esc projectile.
    /// </summary>
    public abstract class RapierProjBase : ModProjectile
    {
        public override void SetDefaults()
        {
            //by default lol, shouldnt ever be changed
            projectile.width = 6;
            projectile.height = 6;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;
            projectile.scale = 1.2f;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
            base.SetDefaults();
        }
        /// <summary>
        /// Creates variables that set the customizable stats of the Rapier esc projectile.
        /// </summary>
        /// <param name="timeLeft"></param>
        public virtual void RapierProjStats(int timeLeft)
        {
            projectile.timeLeft = timeLeft;
        }
        public override void AI()
        {
            Direction = projectile.velocity.SafeNormalize(-Vector2.UnitX);

            Owner.heldProj = projectile.whoAmI;
            Owner.itemAnimation = 2;
            Owner.itemTime = 2;

            projectile.Center = Owner.Center + Direction * Distance + new Vector2(0, Owner.gfxOffY);

            if (!HasPeaked)
                Distance += RapierMoveSpeed;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) => false;

        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture = Main.projectileTexture[projectile.type];

            SpriteEffects sfx = Direction.X > 0 ? SpriteEffects.FlipVertically : SpriteEffects.None;

            float rotation = Direction.X > 0 ? (Direction.ToRotation() + MathHelper.Pi * 1.25f) : (Direction.ToRotation() - MathHelper.Pi * 1.25f);

            spriteBatch.Draw(texture, projectile.Center - Direction * RapierOffset - Main.screenPosition, null, lightColor, rotation, new Vector2(texture.Width >> 1, texture.Height >> 1), 1f, sfx, 1f);

        }
        /// <summary>
        /// Sets the rapier's movement to how ever many pixels per tick/frame.
        /// </summary>
        public virtual float RapierMoveSpeed { get; } = 1f;

        /// <summary>
        /// Sets the rapier's draw offset. Used for moving the sprite so the hitbox can align with the tip.
        /// </summary>
        public virtual int RapierOffset { get; } = 0;

        /// <summary>
        /// Sets the rapier's max distance before it stops.
        /// </summary>
        public virtual bool HasPeaked => Distance >= 0f;

        public virtual float Distance { get; private set; }

        /// <summary>
        /// Sets the rapier's direction.
        /// </summary>
        public Vector2 Direction { get; private set; }

        /// <summary>
        /// Sets the rapier's owner to the current client's player.
        /// </summary>
        public Player Owner => Main.player[projectile.owner];
    }
}
