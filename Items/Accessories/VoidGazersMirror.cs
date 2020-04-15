using Terraria;
using TaoMod;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace TaoMod.Items.Accessories
{
	public class VoidGazersMirror : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("'Gaze into the void and witness your true intentions'\nSummons rotating abyssal mirror shields that will protect you");
		}

		public override void SetDefaults() {
			item.width = 32;
			item.height = 52;
			item.accessory = true;
			item.value = Item.buyPrice(platinum: 1);
			item.rare = 11;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<TaoPlayer>().VoidGazersMirror = true;
		}
	}
}