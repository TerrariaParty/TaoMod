using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using TaoMod;

namespace TaoMod.Items.Accessories
{
	public class Soulbinder : ModItem
	{
		public override void SetStaticDefaults() {

			DisplayName.SetDefault("The Soulbinder");
			Tooltip.SetDefault("'Harvest their souls'\nReduces damage dealt by 35%\n[c/ffe62d:You heal after hitting an enemy]");

		}
		public override void SetDefaults() {
			item.width = 28;
			item.height = 30;
			item.accessory = true;
			item.rare = -12;
			item.maxStack = 1;
			item.value = Item.sellPrice(gold: 15);
			item.expertOnly = true;
			item.alpha = 55;
		}
		public override void UpdateEquip(Player player)
		{
			player.allDamage -= 0.35f;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<TaoPlayer>().HasSoulbinder = true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "DemonRing");
			recipe.AddIngredient(mod, "SoulStone");
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
		}

		}
}

//Now all weapons are Vampire Knives!