using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TaoMod.Items.Materials
{
    class DustHuo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gem Dust (Fire)");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 18;
            item.maxStack = 1;
            item.value = Item.buyPrice(silver: 1);
            item.rare = ItemRarityID.Blue;
        }
    }
}
