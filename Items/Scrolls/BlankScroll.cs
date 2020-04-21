using Terraria.ModLoader;

namespace TaoMod.Items.Scrolls
{
    public class BlankScroll : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blank Scroll"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("It's an empty scroll.\nPerhaps something could be inscribed on it?");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = 0;
            item.rare = 1;
        }


    }
}