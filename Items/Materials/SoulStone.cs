using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace TaoMod.Items.Materials
{
	public class SoulStone : ModItem
	{
		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("Soul Stone");
			Tooltip.SetDefault("You can hear screams coming from this stone");
		}
		public override void SetDefaults()
		{
			item.width = 16;
			item.height = 20;
			item.maxStack = 1;
			item.value = Item.sellPrice(gold: 5);
			item.rare = 8;
			item.alpha = 55;
			item.expertOnly = true;
		}
		class MyGlobalNPC : GlobalNPC
		{
			public override void NPCLoot(NPC npc)
			{
				if (npc.type == NPCID.WallofFlesh)
				{
					if (Main.rand.NextFloat() < .05f)
					{
						Item.NewItem(npc.getRect(), mod.ItemType("SoulStone"), 1);
					}
				}
			}
		}
	}
}

//At one point this would be a Shiny Stone

