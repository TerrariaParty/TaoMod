using Terraria;
using Terraria.ModLoader;
using System.Collections.Generic;
using TaoMod.Items.Consumables;
using System;
using TaoMod.Items.Weapons;

namespace TaoMod
{
	public class TaoPlayer : ModPlayer
	{
		public static TaoPlayer ModPlayer(Player player) {
			return player.GetModPlayer<TaoPlayer>();
		}
		public bool abyssalDebuff;
		public bool VoidGazersMirror;
		public bool riftMinion;
		public bool HasSoulbinder;
		public int cardsCurrent;
		public const int DefaultCardsMax = 10;
		public int cardsMax;
		public int cardsMax2;
		public float cardsRegenRate;
		internal int cardsRegenTimer = 0;
		public override void ResetEffects() {
			ResetVariables();
			abyssalDebuff = false;
			riftMinion = false;
			HasSoulbinder = false;
		}
		public override void Initialize()
		{
			cardsMax = DefaultCardsMax;
			cardsCurrent = 10;
		}
		private void ResetVariables()
		{
			cardsRegenRate = 1f;
			cardsMax2 = cardsMax;
		}
		public override void PostUpdateMiscEffects()
		{
			UpdateResource();
		}
		private void UpdateResource()
		{
			if (Main.LocalPlayer.HeldItem.modItem is TheGamblersFullDeck)
			{
				// For our resource lets make it regen slowly over time to keep it simple, let's use exampleResourceRegenTimer to count up to whatever value we want, then increase currentResource.
				cardsRegenTimer++; //Increase it by 60 per second, or 1 per tick.

				// A simple timer that goes up to 3 seconds, increases the exampleResourceCurrent by 1 and then resets back to 0.
				if (cardsRegenTimer > 80 * cardsRegenRate)
				{
					cardsCurrent += 1;
					cardsRegenTimer = 0;
				}

				// Limit exampleResourceCurrent from going over the limit imposed by exampleResourceMax.
				cardsCurrent = Utils.Clamp(cardsCurrent, 0, cardsMax2);
			}
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

		public override void UpdateDead() {
			ResetVariables();
		}
		public virtual void UpdateLifeRegen() {
			if (abyssalDebuff) {
				// These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
				if (player.lifeRegen > 0) {
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
				player.lifeRegen -= 20;
			}
		}
		public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.LocalPlayer.GetModPlayer<TaoPlayer>().HasSoulbinder == true)
			{
				int amountToHeal = Main.rand.Next(1, 10); // Heal 1 - 10 damage.
				if (amountToHeal + player.statLife > player.statLifeMax2){
					amountToHeal = player.statLifeMax2 - player.statLife; // If healing is larger than health currently missing.
				}
				player.statLife += amountToHeal;
				player.HealEffect(amountToHeal, true);
			}
			base.OnHitNPC(item, target, damage, knockback, crit);
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.LocalPlayer.GetModPlayer<TaoPlayer>().HasSoulbinder == true)
			{
				int amountToHeal = Main.rand.Next(1, 10); // Heal 1 - 10 damage.
				if (amountToHeal + player.statLife > player.statLifeMax2){
					amountToHeal = player.statLifeMax2 - player.statLife; // If healing is larger than health currently missing.
				}
				player.statLife += amountToHeal;
				player.HealEffect(amountToHeal, true);
			}
			base.OnHitNPCWithProj(proj, target, damage, knockback, crit);
		}
	}
}