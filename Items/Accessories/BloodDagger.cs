using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using TaoMod;

namespace TaoMod.Items.Accessories
{
	public class BloodDagger : ModItem
	{
		public override void SetStaticDefaults() {

			DisplayName.SetDefault("Blood Dagger");
			Tooltip.SetDefault("'Blood for the Blood God'\nInflicts bleeding on melee attack\n5% increased melee speed");

		}
		public override void SetDefaults() {
			item.width = 34;
			item.height = 34;
			item.accessory = true;
			item.rare = 1;
			item.maxStack = 1;
			item.value = Item.sellPrice(gold: 2);

		}
		public override void UpdateEquip(Player player)
		{
			player.meleeSpeed += +0.05f;
		}
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<TaoPlayer>().HasBloodDagger = true;
		}
		class MyGlobalNPC : GlobalNPC
		{
			public override void NPCLoot(NPC npc)
			{
				if (npc.type == NPCID.BloodZombie)
				{
					if (Main.rand.NextFloat() < .0500f)
					{
						Item.NewItem(npc.getRect(), mod.ItemType("BloodDagger"));
					}
				}
				if (npc.type == NPCID.Drippler)
				{
					if (Main.rand.NextFloat() < .0500f)
					{
						Item.NewItem(npc.getRect(), mod.ItemType("BloodDagger"));
					}
				}


			}

		}
	}
}

//This bleeding isn't actually Terraria's vanilla bleeding, as it doesn't have effect on enemies