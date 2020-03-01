using Terraria.ID;
using Terraria.ModLoader;

namespace VoidEncounter.Items.VanityItems
{
	[AutoloadEquip(EquipType.Head)]
	public class ManuHoodie : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Manu's Hoodie");
			Tooltip.SetDefault("Great for impersonating friends!");
		}
        public override void SetDefaults()
        {
            item.width = 24; //The size in width of the sprite in pixels.
            item.height = 22;   //The size in height of the sprite in pixels.
            item.rare = 10;    //The color the title of your item when hovering over it ingame 
            item.vanity = true; //this defines if this item is vanity or not.
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 12);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool DrawHead()
        {
            return true;     //this make so the player head does not disappear when the vanity mask is equipped.  return false if you want to not show the player head.
        }
        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;  //this make so the player hair does not show when the vanity mask is equipped.  add true if you want to show the player hair.
        }
    }
}