using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TaoMod.Items.QuestItems
{
    class WuxingGems : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(3, 5));
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
