using System.Collections.Generic;
using System.IO;
using TaoMod.Items.Accessories.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace TaoMod
{
	class TaoWorld : ModWorld
    {
		public static bool downedShaoyin;
		public static bool downedShaoyang;
		public override void Initialize()
		{
			downedShaoyin = false;
			downedShaoyang = false;
		}
		public override TagCompound Save()
		{
			var downed = new List<string>();
			if (downedShaoyin)
			{
				downed.Add("shaoyin");
			}
			if (downedShaoyang)
			{
				downed.Add("shaoyang");
			}
			return new TagCompound
			{
				["downed"] = downed,
			};
		}
		public override void Load(TagCompound tag)
		{
			var downed = tag.GetList<string>("downed");
			downedShaoyin = downed.Contains("shaoyin");
			downedShaoyang = downed.Contains("shaoyang");
		}
		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				downedShaoyin = flags[0];
				downedShaoyang = flags[1];
			}
			else
			{
				mod.Logger.WarnFormat("Tao Mod: Unknown loadVersion: {0}", loadVersion);
			}
		}
		public override void NetSend(BinaryWriter writer)
		{
			//only goes up to flags[7], flags[8] is nonsense
			var flags = new BitsByte();
			flags[0] = downedShaoyin;
			flags[1] = downedShaoyang;
			writer.Write(flags);
		}
		public override void NetReceive(BinaryReader reader)
		{
			BitsByte flags = reader.ReadByte();
			downedShaoyin = flags[0];
			downedShaoyang = flags[1];
		}
		public override void PostWorldGen()
        {
			int[] itemsToPlaceInWoodenChests = { ItemType<EnchantedScabbard>() };
			int itemsToPlaceInWoodenChestsChoice = 0;
			for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
			{
				Chest chest = Main.chest[chestIndex];
				// If you look at the sprite for Chests by extracting Tiles_21.xnb, you'll see that the 12th chest is the Ice Chest. Since we are counting from 0, this is where 11 comes from. 36 comes from the width of each tile including padding. 
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 0 * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == 0)
						{
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInWoodenChests[itemsToPlaceInWoodenChestsChoice]);
							itemsToPlaceInWoodenChestsChoice = (itemsToPlaceInWoodenChestsChoice + 1) % itemsToPlaceInWoodenChests.Length;
							break;
						}
					}
				}
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 1 * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == 0)
						{
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInWoodenChests[itemsToPlaceInWoodenChestsChoice]);
							itemsToPlaceInWoodenChestsChoice = (itemsToPlaceInWoodenChestsChoice + 1) % itemsToPlaceInWoodenChests.Length;
							break;
						}
					}
				}
				if (chest != null && Main.tile[chest.x, chest.y].type == TileID.Containers && Main.tile[chest.x, chest.y].frameX == 2 * 36)
				{
					for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
					{
						if (chest.item[inventoryIndex].type == 0)
						{
							chest.item[inventoryIndex].SetDefaults(itemsToPlaceInWoodenChests[itemsToPlaceInWoodenChestsChoice]);
							itemsToPlaceInWoodenChestsChoice = (itemsToPlaceInWoodenChestsChoice + 1) % itemsToPlaceInWoodenChests.Length;
							break;
						}
					}
				}
			}
        }
    }
}
