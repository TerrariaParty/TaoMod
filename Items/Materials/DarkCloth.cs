using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TaoMod.Items.Materials;

namespace TaoMod.Items.Materials
{
	public class DarkCloth : ModItem
	{
		public override void SetStaticDefaults() {

            DisplayName.SetDefault("Dark Cloth");
			Tooltip.SetDefault("'It was thorn to pieces that day'");
		}
		public override void SetDefaults() {
			item.width = 24;
			item.height = 24;
			item.maxStack = 99;
			item.value = Item.sellPrice(silver: 50);
			item.rare = 5;
		}
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Silk, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
			recipe.AddIngredient(ItemID.SoulofNight, 5);
//			recipe.AddIngredient(mod, "EbonShards", 5);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}

//Just so it has a reason to a scroll, a belt and a scarf become a cape

