using TaoMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TaoMod;

namespace TaoMod.Items.Armor.AbyssalArmor.Greaves
{
	[AutoloadEquip(EquipType.Legs)]
	public class AbyssalGreaves : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Tread with caution, for those who do not fall prey...'\n12% increased movement speed and 5% increased damage");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 0;
			item.rare = 11;
			item.defense = 16;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.12f;
            player.allDamage += 0.05f; 
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<EssenceofYin>(), 15);
            recipe.AddIngredient(ItemType<WhisperingBar>(), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}