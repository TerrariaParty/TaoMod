using TaoMod.Items.Materials;
using TaoMod.Items.Armor.AbyssalArmor.Breastplate;
using TaoMod.Items.Armor.AbyssalArmor.Greaves;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TaoMod;

namespace TaoMod.Items.Armor.AbyssalArmor.Blindfold
{
	[AutoloadEquip(EquipType.Head)]
	public class AbyssalBlindfold : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Those who tamper with the eldritch unknown often go mad'\nIncreases maximum mana by 120 and reduces mana usage by 20%\n5% increased magic damage and crit chance");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 0;
			item.rare = 11;
			item.defense = 16;
		}
        public override void UpdateEquip(Player player){
        	player.magicDamage += 0.05f; 
			player.magicCrit += 5; 
            player.statManaMax2 += 120;
        }
        public override void ModifyManaCost(Player player, ref float reduce, ref float mult) {
			mult *= 0.2f;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<AbyssalBreastplate>() && legs.type == ItemType<AbyssalGreaves>();
		}
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "+8% magic damage\nPressing the Special Ability key will use up all your mana to unleash a burst of energy to damage all enemies on screen\nDamage scales with amount of mana used\nYou slowly go insane";
            player.magicDamage += 0.08f; 
		}
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;  //this make so the player hair does not show when the vanity mask is equipped.  add true if you want to show the player hair.
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<EssenceofYin>(), 10);
            recipe.AddIngredient(ItemID.Silk, 24);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}