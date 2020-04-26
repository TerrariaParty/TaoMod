using TaoMod.Items.Materials;
using TaoMod.Items.Armor.AbyssalArmor.Breastplate;
using TaoMod.Items.Armor.AbyssalArmor.Greaves;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TaoMod;

namespace TaoMod.Items.Armor.AbyssalArmor.Hood
{
	[AutoloadEquip(EquipType.Head)]
	public class AbyssalHood : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Those who tamper with the eldritch unknown often go mad'\nIncreases max minions by 3\n6% increased summon damage");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 0;
			item.rare = 11;
			item.defense = 18;
		}
        public override void UpdateEquip(Player player){
        	player.minionDamage += 0.06f; 
            player.maxMinions += 3;
        }
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<AbyssalBreastplate>() && legs.type == ItemType<AbyssalGreaves>();
		}
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "+10% summon damage\nPressing the Special Ability key will summon a temporary ghastly player to fight for you\nDamage scales with summon damage\nYou slowly go insane";
            player.minionDamage += 0.1f; 
		}
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;  //this make so the player hair does not show when the vanity mask is equipped.  add true if you want to show the player hair.
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<WhisperingBar>(), 10);
            recipe.AddIngredient(ItemID.Silk, 24);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}