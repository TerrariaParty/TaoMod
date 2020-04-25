using Microsoft.Xna.Framework;
using TaoMod.PartialPlayerClasses;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace TaoMod
{
    class TaoGlobalItem : GlobalItem
    {
		public override bool InstancePerEntity => true;
		public override bool CloneNewInstances => true;
		private int BeamTimer = 60;
		private bool CanShootBeam;
		private Vector2 beamSpeed = new Vector2(6);
		public override void HoldItem(Item item, Player player)
		{
			if (Main.LocalPlayer.GetModPlayer<TaoPlayer>().HasEnchantedScabbard == true)
			{
				if (player.HeldItem.melee)
				{
					if (BeamTimer > 0)
					{
						BeamTimer--;
					}
					if (BeamTimer <= 0 && !CanShootBeam)
					{
						Main.PlaySound(new LegacySoundStyle(SoundID.MaxMana, 0), player.Center);
						CanShootBeam = true;
					}
					if (player.itemAnimation == player.itemAnimationMax - 1)
					{
						if (CanShootBeam)
						{
							Projectile.NewProjectile(player.Center, beamSpeed * player.DirectionTo(Main.MouseWorld), ProjectileID.EnchantedBeam, player.HeldItem.damage / 2, 5.25f, player.whoAmI);
							CanShootBeam = false;
							BeamTimer = 60;
							return;
						}
					}
				}
			}
			return;
		}
	}
}
