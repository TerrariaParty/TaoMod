using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using TaoMod.UI;
using Terraria.UI;
using System.Collections.Generic;
using Terraria;

namespace TaoMod
{
	class TaoMod : Mod
	{
		private UserInterface _cardMeterUserInterface;
		private UserInterface _cardMeterInterface;

		public TaoMod()
		{
		}
		public override void Load()
		{
			CardMeter CardMeter = new CardMeter();
			_cardMeterUserInterface = new UserInterface();
			_cardMeterUserInterface.SetState(CardMeter);
			_cardMeterInterface?.SetState(CardMeter);
		}
		public override void Unload()
		{
			_cardMeterInterface = null;
		}
		public override void UpdateUI(GameTime gameTime)
		{
			if (CardMeter.Visible)
			{
				_cardMeterUserInterface?.Update(gameTime);
			}
		}
		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseTextIndex != -1)
			{
				layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
					"Tao Mod: Cards per 80 ticks",
					delegate {
						if (CardMeter.Visible)
						{
							_cardMeterInterface.Draw(Main.spriteBatch, new GameTime());
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
	}
}


