using Terraria.ID;
using Terraria.ModLoader;

namespace TaoMod.Items.QuestItems
{
    class OrnateGemJin : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Shiny and sharp");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 26;
            item.maxStack = 1;
            item.value = 0;
            item.rare = ItemRarityID.Quest;
            item.questItem = true;
        }
    }
}
