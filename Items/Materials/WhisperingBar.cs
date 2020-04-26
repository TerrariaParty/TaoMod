using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TaoMod.Items.Materials;

namespace TaoMod.Items.Materials
{
	public class WhisperingBar : ModItem
	{
		public override void SetStaticDefaults() {

            DisplayName.SetDefault("Whispering Bar");
			Tooltip.SetDefault("'Eerie sounds eminate from the bar itself'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 4));
		}
		public override void SetDefaults() {
			item.width = 34;
			item.height = 40;
			item.maxStack = 99;
			item.value = 95;
			item.rare = 11;
		}
        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<BlissphiteBar>(), 1);
            recipe.AddIngredient(ItemType<CoinofBalance>(), 2);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            //recipe.AddIngredient(ItemType<CoreofYin>(), 4);
            recipe.AddIngredient(ItemID.LunarBar, 3);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}
    }
}

