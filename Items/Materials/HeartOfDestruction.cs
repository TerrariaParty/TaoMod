using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.Items.Materials
{
	public class HeartOfDestruction : ModItem
	{
		public override void SetStaticDefaults() {

            DisplayName.SetDefault("Heart of Destruction");
			Tooltip.SetDefault("'This heart pulses with beats of endless destruction'");
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(24, 2));
		}
		public override void SetDefaults() {
			item.width = 19;
			item.height = 20;
			item.maxStack = 999;
			item.value = Item.sellPrice(gold: 25);
			item.rare = -12;
			item.expertOnly = true;
		}
		class MyGlobalNPC : GlobalNPC
		{
			public override void NPCLoot(NPC npc)
			{
				if (!npc.friendly)
				{
					if (Main.rand.NextFloat() < 0.0001f)
					{
						Item.NewItem(npc.getRect(), mod.ItemType("HeartOfDestruction"));
					}
				}


			}

		}
	}
}

//Yep, I have no heart, in both senses

