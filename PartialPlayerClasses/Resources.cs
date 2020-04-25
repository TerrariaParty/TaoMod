using Terraria;
using Terraria.ModLoader;
using TaoMod.Items.Weapons;

namespace TaoMod.PartialPlayerClasses
{
	public partial class TaoPlayer : ModPlayer
	{
		public int cardsCurrent;
		public const int DefaultCardsMax = 10;
		public int cardsMax;
		public int cardsMax2;
		public float cardsRegenRate;
		internal int cardsRegenTimer = 0;
		public const int DefaultInsanityMax = 50;
		public int insanityMax;
		public int insanityMax2;
		public float insanityRegenRate;
		internal int insanityRegenTimer = 0;
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
	}
}
