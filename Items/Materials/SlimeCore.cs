using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace TaoMod.Items.Materials
{
    public class SlimeCore : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 10;
            item.height = 12;
            item.maxStack = 999;
            item.alpha = 175;
            item.ammo = AmmoID.Gel;
            item.color = new Color(0, 80, 255, 100);
            item.value = 7;
            item.consumable = true;
        }
    }
}
