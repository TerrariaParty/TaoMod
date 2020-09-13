using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace TaoMod.Items.Accessories
{
    class EmptyAmulet : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 24;
            item.maxStack = 1;
            item.value = Item.buyPrice(gold: 1);
            item.rare = ItemRarityID.White;
        }
    }
}
