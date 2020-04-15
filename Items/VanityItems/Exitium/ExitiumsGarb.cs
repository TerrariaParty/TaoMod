using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.Items.VanityItems.Exitium
{
	[AutoloadEquip(EquipType.Body)]
	public class ExitiumsGarb : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Exitium's Garb");
			Tooltip.SetDefault("'Great for impersonating developers!'");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 0;
			item.rare = 9;
            item.vanity = true;
		}
	}
}