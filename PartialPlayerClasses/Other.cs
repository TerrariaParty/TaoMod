using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using TaoMod.Items.Consumables;
using System;

namespace TaoMod.PartialPlayerClasses
{
	public partial class TaoPlayer : ModPlayer
	{
		public static TaoPlayer ModPlayer(Player player)
		{
			return player.GetModPlayer<TaoPlayer>();
		}
		public override void ResetEffects()
		{
			ResetVariables();
			HasSoulbinder = false;
			HasBloodDagger = false;
			HasVoidGazersMirror = false;
			HasMoonNecklace = false;
			HasEnchantedScabbard = false;
			abyssalDebuff = false;
			riftMinion = false;
			pcBleeding = false;
		}
		public override void UpdateDead()
		{
			ResetVariables();
		}
		private void AddStartItem(ref IList<Item> items, int itemType, int stack = 1)
		{
			Item item = new Item();
			item.SetDefaults(itemType);
			item.stack = stack;
			items.Add(item);
		}
		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
		{
			Item item = new Item();
			item.SetDefaults(ModContent.ItemType<CubesOfManyWonders>());
			item.stack = 1;
			items.Add(item);
		}

		private int ItemType<T>()
		{
			throw new NotImplementedException();
		}
	}
}
