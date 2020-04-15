using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TaoMod.Items.Materials;

namespace TaoMod.Items.Consumables
{
	public class CubesOfManyWonders : ModItem
	{
		public override void SetStaticDefaults()
		{

			DisplayName.SetDefault("Cubes of Many Wonders");
			Tooltip.SetDefault("Right-Click to open\nWho knows what's contained within these cubes?");	}
		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 28;
			item.maxStack = 1;
			item.value = Item.sellPrice(silver: 30);
			item.rare = 0;
		}
		public override bool CanRightClick()
		{
			return true;
		}

		public override void RightClick(Player player)
		{
			player.QuickSpawnItem(ItemID.IronBroadsword, 1);
			player.QuickSpawnItem(ItemID.IronBow, 1);
			player.QuickSpawnItem(ItemID.WandofSparking, 1);
			player.QuickSpawnItem(ItemID.SlimeStaff, 1);
			player.QuickSpawnItem(ItemID.IronPickaxe, 1);
			player.QuickSpawnItem(ItemID.IronAxe, 1);
			player.QuickSpawnItem(ItemID.Rope, 50);
			player.QuickSpawnItem(ItemID.Bomb, 3);
			player.QuickSpawnItem(ItemID.LesserHealingPotion, 10);
			player.QuickSpawnItem(ItemID.LesserManaPotion, 10);
			player.QuickSpawnItem(ItemID.LifeCrystal, 2);
			player.QuickSpawnItem(ItemID.ManaCrystal, 2);
			player.QuickSpawnItem(ItemID.IronskinPotion, 3);
			player.QuickSpawnItem(ItemID.MiningPotion, 3);
			player.QuickSpawnItem(ItemID.RegenerationPotion, 3);
			player.QuickSpawnItem(ItemID.SwiftnessPotion, 3);
			player.QuickSpawnItem(ItemID.SpelunkerPotion, 1);
			player.QuickSpawnItem(ItemID.RecallPotion, 5);
		}
	}
}


