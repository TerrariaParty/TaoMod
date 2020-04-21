using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using TaoMod;

namespace TaoMod.Items.Accessories
{
	[AutoloadEquip(EquipType.Neck)]
	public class MoonStoneNecklace : ModItem
	{
		public override void SetStaticDefaults() {

			DisplayName.SetDefault("Moon Stone Necklace");
			Tooltip.SetDefault("[c/a3cfed:'Memento mori']\nIncreases magic damage by 15%\nYou gain mana after killing an enemy");

		}
		public override void SetDefaults() {
			item.width = 36;
			item.height = 20;
			item.accessory = true;
			item.rare = -12;
			item.maxStack = 1;
			item.value = Item.sellPrice(gold: 10);
			item.expertOnly = true;
		}
		public override void UpdateEquip(Player player)
		{
			player.magicDamage += 0.15f;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<TaoPlayer>().HasMoonNecklace = true;
		}
		class MyGlobalNPC : GlobalNPC
		{
			public override void NPCLoot(NPC npc)
			{
				if (npc.type == NPCID.DungeonSpirit)
				{
					if (Main.rand.NextFloat() < .01f)
					{
						Item.NewItem(npc.getRect(), mod.ItemType("MoonStoneNecklace"));
					}
				}
			}
		}
	}
}

//I miss you