using Terraria;
using Terraria.ModLoader;

namespace TaoMod.PartialPlayerClasses
{
	public partial class TaoPlayer : ModPlayer
	{
		public bool abyssalDebuff;
		public bool pcBleeding;
		public bool riftMinion;
		public virtual void UpdateLifeRegen() {
			if (abyssalDebuff)
			{
				// These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
				player.lifeRegen -= 20;
			}
			if (pcBleeding)
			{
				// These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
				player.lifeRegen -= 30;
			}
		}
	}
}
