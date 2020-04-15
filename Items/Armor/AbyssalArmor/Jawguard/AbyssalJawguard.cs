using TaoMod.Items.Materials;
using TaoMod.Items.Armor.AbyssalArmor.Breastplate;
using TaoMod.Items.Armor.AbyssalArmor.Greaves;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TaoMod;

namespace TaoMod.Items.Armor.AbyssalArmor.Jawguard
{
	[AutoloadEquip(EquipType.Head)]
	public class AbyssalJawguard : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Those who tamper with the eldritch unknown often go mad'\nIncreases projectile speed by 10%\n5% increased ranged damage and crit chance");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 0;
			item.rare = 11;
			item.defense = 20;
		}
        public override void UpdateEquip(Player player){
        	player.rangedDamage += 0.05f; 
			player.rangedCrit += 5; 
        }
		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<AbyssalBreastplate>() && legs.type == ItemType<AbyssalGreaves>();
		}
		public override void UpdateArmorSet(Player player) {
			player.setBonus = "+7% ranged damage\nPressing the Special Ability key will call down a rain of abyssal shards from the sky for 5 seconds\nDamage scales with ranged damage\nYou slowly go insane";
            player.rangedDamage += 0.07f; 
		}
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;  //this make so the player hair does not show when the vanity mask is equipped.  add true if you want to show the player hair.
        }
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<EssenceofYin>(), 10);
            recipe.AddIngredient(ItemType<WhisperingBar>(), 12);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}