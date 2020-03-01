using Terraria.ID;
using Terraria.ModLoader;

namespace VoidEncounter.Items.Materials
{
	public class AbyssalFragment : ModItem
	{
		public override void SetStaticDefaults() {

            DisplayName.SetDefault("Abyssal Fragment");
			Tooltip.SetDefault("'You can almost feel your brain tipping into insanity'\nThe Abyssal Mage might be interested in this");
		}
		public override void SetDefaults() {
			item.width = 16;
			item.height = 22;
			item.maxStack = 99;
			item.value = 100;
			item.rare = 11;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}
    }
}

