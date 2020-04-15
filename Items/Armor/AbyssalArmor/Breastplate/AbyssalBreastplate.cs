using TaoMod.Items.Materials;
using TaoMod.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TaoMod;

namespace TaoMod.Items.Armor.AbyssalArmor.Breastplate
{
	[AutoloadEquip(EquipType.Body)]
	public class AbyssalBreastplate : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Abyssal Breastplate");
			Tooltip.SetDefault("'Careful for your sanity'\n10% increased damage and crit chance\nImmunity to Abyssal Flames");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 0;
			item.rare = 11;
			item.defense = 20;
		}

		public override void UpdateEquip(Player player) {
			player.allDamage += 0.1f; 
			player.meleeCrit += 10; 
			player.rangedCrit += 10; 
			player.magicCrit += 10; 
			player.thrownCrit += 10; 
			player.buffImmune[BuffType<AbyssalDebuff>()] = true;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<EssenceofYin>(), 20);
            recipe.AddIngredient(ItemType<WhisperingBar>(), 16);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}