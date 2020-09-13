using Terraria.ID;
using Terraria.ModLoader;

namespace TaoMod.Items.QuestItems
{
    class OrnateGemTu : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Very brittle");
        }
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.maxStack = 1;
            item.value = 0;
            item.rare = ItemRarityID.Quest;
            item.questItem = true;
        }
    }
}
