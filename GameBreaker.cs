using Terraria.ID;
using Terraria.ModLoader;

namespace VoidEncounter.Items.WackItems
{
	public class GameBreaker : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Game Breaker");
			Tooltip.SetDefault("Wow! You got the Game Breaker! This... doesn't actually do anything cool. Sorry.");
		}
		public override void SetDefaults()
		{
			item.value = 10000;
			item.rare = -12;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 0);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
