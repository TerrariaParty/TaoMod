using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;
using System.Linq;

namespace TaoMod
{
   public class ItemListings
   {
      public List<int> ShortswordList() {
         List<int> shortswords = new List<int>();
         shortswords.Add(ItemID.CopperShortsword);
         shortswords.Add(ItemID.GoldShortsword);
         shortswords.Add(ItemID.IronShortsword);
         shortswords.Add(ItemID.LeadShortsword);
         shortswords.Add(ItemID.PlatinumShortsword);
         shortswords.Add(ItemID.SilverShortsword);
         shortswords.Add(ItemID.TinShortsword);
         shortswords.Add(ItemID.TungstenShortsword);
         return shortswords;
      } 
      public static List<int> ScrollList()
      {
         List<int> scrolls = new List<int>();
         scrolls.Add(ItemType<Items.Scrolls.BlankScroll>());
         scrolls.Add(ItemType<Items.Scrolls.ShortswordScroll>());
         return scrolls;
      }
}
}
