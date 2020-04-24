using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using TaoMod.Items.Materials;

namespace TaoMod.Items.Accessories.Summoner
{
	[AutoloadEquip(EquipType.Front, EquipType.Back)]
	public class DarkKingsCape : ModItem
	{
		public override void SetStaticDefaults() {

			DisplayName.SetDefault("Dark King's Cape");
			Tooltip.SetDefault("'Once worn by the shadow tyrant, now it's yours'\nYou are powerful during the night, but weak when the sun is out\nReduces damage taken by 12%\nIncreases your max number of minions\nGives a chance to dodge attacks");

		}
		public override void SetDefaults() {
			item.width = 28;
			item.height = 34;
			item.accessory = true;
			item.rare = -12;
			item.maxStack = 1;
			item.value = Item.sellPrice(gold: 15);
		}
		public override void UpdateEquip(Player player)
		{
			player.maxMinions += 1;
			player.blackBelt = true;
			player.endurance += 0.12f;

			if (Main.dayTime == false) {

				player.minionDamage += 0.10f;
				player.moveSpeed += 0.50f;
				player.statDefense += 8;
			}
			if (Main.dayTime == true)
			{
				player.minionDamage -= 0.08f;
				player.statDefense -= 15;
				player.moveSpeed -= 0.25f;
			}
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod, "DarkCloth", 10);
			recipe.AddIngredient(ItemID.WormScarf);
			recipe.AddIngredient(ItemID.NecromanticScroll);
			recipe.AddIngredient(ItemID.BlackBelt);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}

//Just take it off during the day