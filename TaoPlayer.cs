using Terraria;
using Terraria.ID;
using TaoMod.Items.Accessories;
using TaoMod.Buffs;
using Terraria.ModLoader;
using System.Threading.Tasks;
using TaoMod.UI;
using System.Collections.Generic;
using System.Linq;

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
		public override void ResetEffects() {
			ResetVariables();
			abyssalDebuff = false;
			riftMinion = false;
		}

		public override void UpdateDead() {
			ResetVariables();
		}

	    private void ResetVariables() {
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
	}
}