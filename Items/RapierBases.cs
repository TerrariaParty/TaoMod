using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TaoMod.Items
{
    //start of the rapier inheritance class
    public abstract class RapierBase : ModItem
    {
        public override void SetDefaults()
        {
            base.SetDefaults();

            //some defaults that cannot be changed
            item.channel = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.autoReuse = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;

            //calls the RapierStats method to input the rest of the stats
            RapierStats();
        }
        public void RapierStats()
        {
            //declare all valid variables that can be inputted
            int damage = 0;
            int crit = 0;
            float knockback = 0f;
            int useSpeed = 0;
            int rarity = 0;
            int value = 0;
            int rapierProjectile = 0;

            //sets the stats after variables are declared
            item.damage = damage;
            item.crit = crit;
            item.knockBack = knockback;
            item.useTime = useSpeed;
            item.useAnimation = useSpeed;
            item.rare = rarity;
            item.value = value;
            item.shoot = rapierProjectile;
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
    }

    //i'll start the rapier projectile inhertied class here, since making another file is uh, wack
    //code taken from example mod cause i'm lazy 😎 
    //credit to examplemod, chicken bones, joifarden, blushiemagic, and javidpack (the contributors to this file specifically, ExampleSpearProjectile.cs
    public abstract class RapierProjBase : ModProjectile
    {
        //declare the variable for use
        public int rapierMoveSpeed = 0;

        public override void SetDefaults()
        {
            //by default lol, shouldnt ever be changed
            projectile.width = 6;
            projectile.height = 6;
            projectile.aiStyle = 19;
            projectile.penetrate = -1;
            projectile.scale = 1.2f;
            projectile.hide = true;
            projectile.ownerHitCheck = true;
            projectile.melee = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
        }

        public void RapierProjStats()
        {
            rapierMoveSpeed = 0;
        }

        // In here the AI uses this example, to make the code more organized and readable
        // Also showcased in ExampleJavelinProjectile.cs
        public float MovementFactor // Change this value to alter how fast the spear moves
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = rapierMoveSpeed;
        }

        // It appears that for this AI, only the ai0 field is used!
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
                    MovementFactor = 3f; // Make sure the spear moves forward when initially thrown out
                    projectile.netUpdate = true; // Make sure to netUpdate this spear
                }
                if (projOwner.itemAnimation < projOwner.itemAnimationMax / 3) // Somewhere along the item animation, make sure the spear moves back
                {
                    MovementFactor -= 2.4f;
                }
                else // Otherwise, increase the movement factor
                {
                    MovementFactor += 2.1f;
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
            // Offset by 90 degrees here
            if (projectile.spriteDirection == -1)
            {
                projectile.rotation -= MathHelper.ToRadians(90f);
            }
        }
    }
}
