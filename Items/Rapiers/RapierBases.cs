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

    /// <summary>
    /// Inherited class. Sets up the basics for a Rapier esc projectile.
    /// </summary>
    public abstract class RapierProjBase : ModProjectile
    {
        public override void SetDefaults()
        {
            //basic variables, no need to change
            projectile.width = 9;
            projectile.height = 9;
            projectile.penetrate = -1;
            projectile.aiStyle = 19;
            projectile.friendly = true;
            projectile.tileCollide = false;

            base.SetDefaults();
        }

        /// <summary>
        /// Sets the movement speed of the rapier projectile.
        /// </summary>
        public virtual float MovementFactor => 0;
        public float movementFactor // Change this value to alter how fast the spear moves
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = MovementFactor;
        }
        public override void AI()
        {
            // Since we access the owner player instance so much, it's useful to create a helper local variable for this
            // Sadly, Projectile/ModProjectile does not have its own
            Player projOwner = Main.player[projectile.owner];
            // Here we set some of the projectile's owner properties, such as held item and itemtime, along with projectile direction and position based on the player
            Vector2 ownerMountedCenter = projOwner.RotatedRelativePoint(projOwner.MountedCenter, true);
            projectile.direction = projOwner.direction;
            projOwner.heldProj = projectile.whoAmI;
            projOwner.itemTime = projOwner.itemAnimation;
            projectile.position.X = ownerMountedCenter.X - (float)(projectile.width / 2);
            projectile.position.Y = ownerMountedCenter.Y - (float)(projectile.height / 2);
            // As long as the player isn't frozen, the spear can move
            if (!projOwner.frozen)
            {
                if (MovementFactor == 0f) // When initially thrown out, the ai0 will be 0f
                {
                    movementFactor = 3f; // Make sure the spear moves forward when initially thrown out
                    projectile.netUpdate = true; // Make sure to netUpdate this spear
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
                {
                    movementFactor -= 2.4f;
                }
                else // Otherwise, increase the movement factor
                {
                    movementFactor += 2.1f;
                }
            }
            // Change the spear position based off of the velocity and the movementFactor
            projectile.position += projectile.velocity * MovementFactor;
            // When we reach the end of the animation, we can kill the spear projectile
            if (projOwner.itemAnimation == 0)
            {
                projectile.Kill();
            }
            // Apply proper rotation, with an offset of 135 degrees due to the sprite's rotation, notice the usage of MathHelper, use this class!
            // MathHelper.ToRadians(xx degrees here)
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(135f);
            base.AI();
        }
    }
}
