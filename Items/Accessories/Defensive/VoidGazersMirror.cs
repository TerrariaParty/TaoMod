using TaoMod.PartialPlayerClasses;
using Terraria;
using Terraria.ModLoader;

namespace TaoMod.Items.Accessories.Defensive
{
	public class VoidGazersMirror : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Void Gazer's Mirror");
			Tooltip.SetDefault("'Gaze into the void and witness your true self'\nSummons your shadow to protect you");
		}

		public override void SetDefaults() {
			item.width = 32;
			item.height = 52;
			item.accessory = true;
			item.value = Item.buyPrice(platinum: 1);
			item.rare = 11;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.GetModPlayer<TaoPlayer>().HasVoidGazersMirror = true;
		}
	}
}