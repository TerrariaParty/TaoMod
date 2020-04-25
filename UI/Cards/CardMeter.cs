using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TaoMod.Items.Weapons;
using TaoMod.PartialPlayerClasses;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.UI
{
	internal class CardMeter : UIState
	{
		private UIImage barFrame { get; set; } = new UIImage(GetTexture("TaoMod/UI/Cards/EmptyCards"));
		private UIElement cardsMeter = new UIElement();
		public static bool Visible;
		public override void OnInitialize()
		{
			cardsMeter.Append(barFrame);
			Append(cardsMeter);
		}
		private Vector2 pee = new Vector2(0, 32);
		private void SetPosition(UIElement element, Vector2 pos)
		{
			SetPosition(cardsMeter, Main.LocalPlayer.Center - Main.screenPosition + pee);
		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			// This prevents drawing unless we are using an ExampleDamageItem
			if (!(Main.LocalPlayer.HeldItem.modItem is TheGamblersFullDeck))
			{
				Visible = true;
				return;
			}
			else
			{
				Visible = false;
			}
			base.Draw(spriteBatch);
		}
		public override void Update(GameTime gameTime)
		{
			if (!(Main.LocalPlayer.HeldItem.modItem is TheGamblersFullDeck))
			{
				return;
			}
			var modPlayer = Main.LocalPlayer.GetModPlayer<TaoPlayer>();
			if(modPlayer.cardsCurrent == 1)
			{
			}
			base.Update(gameTime);
		}
	}
}
