using Terraria;
using Terraria.ModLoader;
using TaoMod.Items.Materials;
using static Terraria.ModLoader.ModContent;
using TaoMod.Items.Accessories.ExpertDrops;

namespace TaoMod.Items.Consumables
{
	public class ShaoyangTreasureBag : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treasure Bag");
			Tooltip.SetDefault("{$CommonItemTooltip.RightClickToOpen}");
		}

		public override void SetDefaults()
		{
			item.maxStack = 999;
			item.consumable = true;
			item.width = 24;
			item.height = 24;
			item.rare = -12;
			item.expert = true;
		}

		public override bool CanRightClick()
		{
			return true;
		}

		public override void OpenBossBag(Player player)
		{
			player.TryGettingDevArmor();
			if (Main.rand.NextBool(7))
			{
				//player.QuickSpawnItem(ItemType<ShaoyangMask>());
			}
			player.QuickSpawnItem(ItemType<EssenceofYang>(), Main.rand.Next(5, 10));
			player.QuickSpawnItem(ItemType<EssenceOfShaoyang>());
		}

		public override int BossBagNPC => NPCType<NPCs.Shaoyang.Shaoyang>();
	}
}