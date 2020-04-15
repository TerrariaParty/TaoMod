using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TaoMod.Items.Materials;

namespace TaoMod.Items.Materials
{
	public class BlissphiteBar : ModItem
	{
		public override void SetStaticDefaults() {

            DisplayName.SetDefault("Blissphite Bar");
			Tooltip.SetDefault("'It glows with immense heat'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(7, 10));
		}
		public override void SetDefaults() {
			item.width = 34;
			item.height = 28;
			item.maxStack = 99;
			item.value = 95;
			item.rare = 11;
		}
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<WhisperingBar>(), 1);
            recipe.AddIngredient(ItemType<CoinofBalance>(), 2);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<EssenceofYang>(), 4);
            recipe.AddIngredient(ItemID.LunarBar, 3);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}
    }
}

