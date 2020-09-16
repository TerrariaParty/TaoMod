using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.UI
{
	internal class SpiritMeter : UIState
	{
		private UIText text;
		private UIElement area;
		private UIImage barFrame;

		public override void OnInitialize()
		{
			area = new UIElement();
			area.Left.Set(-area.Width.Pixels - 600, 1f); // Place the resource bar to the left of the hearts.
			area.Top.Set(30, 0f); // Placing it just a bit below the top of the screen.
			area.Width.Set(182, 0f); // We will be placing the following 2 UIElements within this 182x60 area.
			area.Height.Set(60, 0f);

			barFrame = new UIImage(GetTexture("TaoMod/UI/SpiritMeter"));
			barFrame.Left.Set(22, 0f);
			barFrame.Top.Set(0, 0f);
			barFrame.Width.Set(138, 0f);
			barFrame.Height.Set(34, 0f);

			text = new UIText("0/0", 0.8f); 
			text.Width.Set(138, 0f);
			text.Height.Set(34, 0f);
			text.Top.Set(40, 0f);
			text.Left.Set(0, 0f);

			area.Append(text);
			area.Append(barFrame);
			Append(area);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			/*if (!(Main.LocalPlayer.HeldItem.modItem is ExampleDamageItem))
				return;*/

			return;
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);

			var modPlayer = Main.LocalPlayer.GetModPlayer<TaoPlayer>();

			float quotient = (float)modPlayer.spiritMeterCurrent / modPlayer.spiritMeterMax2; 
			quotient = Utils.Clamp(quotient, 0f, 1f); 

			Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
			hitbox.X += 12;
			hitbox.Width -= 24;
			hitbox.Y += 8;
			hitbox.Height -= 16;
		}
		public override void Update(GameTime gameTime)
		{
			/*if (!(Main.LocalPlayer.HeldItem.modItem is ExampleDamageItem))
				return;*/

			var modPlayer = Main.LocalPlayer.GetModPlayer<TaoPlayer>();
			text.SetText($"Spirit Meter: {modPlayer.spiritMeterCurrent} / {modPlayer.spiritMeterMax2}");
			return;
		}
	}
}