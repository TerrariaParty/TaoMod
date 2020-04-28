using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using TaoMod.NPCs.Shaoyang;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.Items
{
    public class TomeOfEndlessWisdom : ModItem
    {
        public int Timer;

        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Tome of Endless Wisdom");
            Tooltip.SetDefault("'Once per day you may ask the book for wisdom, and yes, the book is sentient'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 10));
        }
        public override void SetDefaults(){
            item.noMelee = true;
            item.noUseGraphic = true;
            item.useStyle = 4;
            item.useTime = 45;
            item.useAnimation = 45;
            item.width = 28;
            item.height = 38;
            item.maxStack = 1;
            item.rare = 9;
        }
         public override bool CanUseItem(Player player){
            Timer++;
            return Timer > 180;
        }
        public override bool UseItem(Player player)
        {

            
                Main.PlaySound(SoundID.Item24);
                switch (Main.rand.Next(3))
                {
                    case 0:
                        Main.NewText("1");
                        break;
                    case 1:
                        Main.NewText("2");
                        break;
                    case 2:
                        Main.NewText("[c/00add2:3]");
                        break;
                }
                Timer = 0;
            
                return true;
                }
    }
}