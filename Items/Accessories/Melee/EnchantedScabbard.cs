using TaoMod.PartialPlayerClasses;
using Terraria;
using Terraria.ModLoader;

namespace TaoMod.Items.Accessories.Melee
{
	public class EnchantedScabbard : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Grants your melee weapons the ability to shoot an enchanted beam\n+20% melee speed");
		}
		public override void SetDefaults()
		{
			item.width = 32;
			item.height = 36;
			item.accessory = true;
			item.value = Item.buyPrice(silver: 15);
			item.rare = 1;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeSpeed += .2f;
			player.statDefense += 1;
			player.GetModPlayer<TaoPlayer>().HasEnchantedScabbard = true;
		}
	}
}