using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using TaoMod.Items.Accessories;
using static Terraria.ModLoader.ModContent;

namespace TaoMod
{
	class TaoMod : Mod
	{
		public TaoMod()
		{
		}
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(ModContent.ItemType<AbyssalEmblem>(), 1);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
			recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(ItemID.AvengerEmblem);
			recipe.AddRecipe();
		}
	}
}

