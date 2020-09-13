using Terraria.ID;
using Terraria.ModLoader;

namespace TaoMod.Items.QuestItems
{
    class OrnateGemMu : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Smells of grass");
        }
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.maxStack = 1;
            item.value = 0;
            item.rare = ItemRarityID.Quest;
            item.questItem = true;
        }
    }
}
