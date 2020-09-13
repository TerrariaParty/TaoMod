using Terraria.ID;
using Terraria.ModLoader;

namespace TaoMod.Items.QuestItems
{
    class OrnateGemHuo : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Radiates extreme heat");
        }
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 24;
            item.maxStack = 1;
            item.value = 0;
            item.rare = ItemRarityID.Quest;
            item.questItem = true;
        }
    }
}
