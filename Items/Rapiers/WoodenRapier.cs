using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.Items.Rapiers
{
    class WoodenRapier : RapierBase
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Right click to parry");
        }
        public override void SetDefaults()
        {
            RapierStats(5, 0, 2.5f, 24, 0, 20, false, ProjectileType<WoodenRapierProj>(), 8f);
            base.SetDefaults();
        }
        public override bool CanRightClick()
        {
            return true;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    class WoodenRapierProj : RapierProjBase 
    {
        public override void SetDefaults()
        {
            RapierProjStats(24);
            base.SetDefaults();
        }
        public override void AI()
        {
            base.AI();
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            return base.PreDraw(spriteBatch, lightColor);
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            base.PostDraw(spriteBatch, lightColor);
        }
        public override bool HasPeaked => Distance >= 32f;
        public override float RapierMoveSpeed => 8f;
        public override int RapierOffset => 15;
    }
}
