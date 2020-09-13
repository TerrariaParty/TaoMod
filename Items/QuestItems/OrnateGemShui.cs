using Terraria.ID;
using Terraria.ModLoader;

namespace TaoMod.Items.QuestItems
{
    class OrnateGemShui : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Almost feels wet");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 28;
            item.maxStack = 1;
            item.value = 0;
            item.rare = ItemRarityID.Quest;
            item.questItem = true;
        }
    }
}
