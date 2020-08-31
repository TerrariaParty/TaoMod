using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.Items.Rapiers
{
    class RichMahoganyRapier : RapierBase
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Right click to perform a dash that gives temporary invincibility");
        }
        public override void SetDefaults()
        {
            RapierStats(6, 0, 2.5f, 23, 0, 20, false, ProjectileType<RichMahoganyRapierProj>(), 8f);
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
            recipe.AddIngredient(ItemID.RichMahogany, 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    class RichMahoganyRapierProj : RapierProjBase
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
        }
        public override float MovementFactor => 6;
        public override void AI()
        {
            base.AI();
        }
    }
}