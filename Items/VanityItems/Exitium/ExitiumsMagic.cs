using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.Items.VanityItems.Exitium
{
	[AutoloadEquip(EquipType.Wings)]
	public class ExitiumsMagic : ModItem
	{

		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Exitium's Magic");
			Tooltip.SetDefault("'Great for impersonating developers!'");
		}

		public override void SetDefaults() {
			item.width = 22;
			item.height = 20;
			item.value = 10000;
			item.rare = 9;
			item.accessory = true;
		}
		public override void UpdateAccessory(Player player, bool hideVisual) {
			player.wingTimeMax = 150;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend) {
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 3f;
			constantAscend = 0.135f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration) {
			speed = 9f;
			acceleration *= 2.5f;
		}
    }
}
