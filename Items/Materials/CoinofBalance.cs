using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.Items.Materials
{
	public class CoinofBalance : ModItem
	{
		public override void SetStaticDefaults() {

            DisplayName.SetDefault("Coin of Balance");
			Tooltip.SetDefault("'Like all things should be'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 8));
		}
		public override void SetDefaults() {
			item.width = 32;
			item.height = 32;
			item.maxStack = 999;
			item.value = 0;
			item.scale = 0.8f;
			item.rare = -12;
		}
    }
}

