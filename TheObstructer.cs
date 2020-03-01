using Terraria.ID;
using Terraria.ModLoader;

namespace VoidEncounter.Items.VanityItems
{
	[AutoloadEquip(EquipType.Head)]
	public class TheObstructer : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Obstructer");
			Tooltip.SetDefault("What this item does to you is not a bug!");
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
			recipe.AddIngredient(ItemID.DirtBlock, 0);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        public override bool DrawHead()
        {
            return false;     //this make so the player head does not disappear when the vanity mask is equipped.  return false if you want to not show the player head.
        }
        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;  //this make so the player hair does not show when the vanity mask is equipped.  add true if you want to show the player hair.
        }
    }
}