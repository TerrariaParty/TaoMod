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
        private bool CanUse;

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
        public override void UpdateInventory(Player player)
        {
            if (Main.time == 0 && CanUse == false && Main.dayTime)
            {
                CanUse = true;
            }
            if (player.name == "Exitium")
            {
                CanUse = true;
            }
            return;
                }

        public override bool UseItem(Player player)
        {
            if (CanUse == true)
            {
                Main.PlaySound(SoundID.Item24);
                switch (Main.rand.Next(9))
                {
                    case 0:
                        Main.NewText("[c/00add2:A cookie a day keeps depression away.]");
                        player.QuickSpawnItem(ItemID.Marshmallow, 1); //placeholder
                        break;
                    case 1:
                        Main.NewText("[c/00add2:Always remember, it's only a crime if they get you.]");
                        player.QuickSpawnItem(ItemID.DiamondRing, 1);
                        break;
                    case 2:
                        Main.NewText("[c/00add2:Oh My! Look at the time.]");
                        player.QuickSpawnItem(ItemID.GoldWatch, 1);
                        break;
                    case 3:
                        Main.NewText("[c/00add2:Remember that you can always get this in the Pyramids.]");
                        player.QuickSpawnItem(ItemID.PharaohsMask, 1);
                        player.QuickSpawnItem(ItemID.PharaohsRobe, 1);
                        break;
                    case 4:
                        Main.NewText("[c/00add2:Don't ask where I got this; though you should run. He's angry.]");
                        player.QuickSpawnItem(ItemID.SuspiciousLookingEye, 1); //placeholder
                        break;
                    case 5:
                        Main.NewText("[c/00add2:Don't ping everyone.]");
                        player.QuickSpawnItem(ItemID.SlapHand, 1);
                        break;
                    case 6:
                        Main.NewText("[c/00add2:The ancient forces of light and dark are in balance.]");
                        player.QuickSpawnItem(ItemID.CelestialStone, 1);
                        break;
                    case 7:
                        Main.NewText("[c/00add2:Everyone could use a new perspective in life.]");
                        player.QuickSpawnItem(ItemID.EyeoftheGolem, 1);
                        break;
                    case 8:
                        Main.NewText("[c/00add2:Do you believe in fate?]");
                        player.QuickSpawnItem(ItemID.TinCan, 1);
                        break;
                }
            }
            else
            {
                Main.PlaySound(SoundID.Item24);
                Main.NewText("[c/00add2:The tome doesn't want to share wisdom with you now]");
            }
            CanUse = false;
                return true;
        }
    }
}

//My favorite item