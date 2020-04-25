using Terraria;
using Terraria.ModLoader;
using TaoMod.Buffs;

namespace TaoMod.PartialPlayerClasses
{
	public partial class TaoPlayer : ModPlayer
	{
		public bool HasVoidGazersMirror;
		public bool HasSoulbinder;
		public bool HasMoonNecklace;
		public bool HasBloodDagger;
		public bool HasEnchantedScabbard;
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
			if (Main.LocalPlayer.GetModPlayer<TaoPlayer>().HasBloodDagger == true)
			{
				if (player.HeldItem.melee)
				{
					target.AddBuff(ModContent.BuffType<Bleedingg>(), 600);
				}
			}
			if (Main.LocalPlayer.GetModPlayer<TaoPlayer>().HasMoonNecklace == true)
			{
				if (player.HeldItem.magic)
				{
					if (target.life <= 0)
					{
						player.statMana += Main.rand.Next(50, 86);
					}
				}
			}
			base.OnHitNPC(item, target, damage, knockback, crit);
		}
		public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.LocalPlayer.GetModPlayer<TaoPlayer>().HasSoulbinder == true)
			{
				int amountToHeal = Main.rand.Next(1, 10); // Heal 1 - 10 damage.
				if (amountToHeal + player.statLife > player.statLifeMax2)
				{
					amountToHeal = player.statLifeMax2 - player.statLife; // If healing is larger than health currently missing.
				}
				player.statLife += amountToHeal;
				player.HealEffect(amountToHeal, true);
			}
			if (Main.LocalPlayer.GetModPlayer<TaoPlayer>().HasBloodDagger == true)
			{
				if (player.HeldItem.melee)
				{
					target.AddBuff(ModContent.BuffType<Bleedingg>(), 600);
				}
			}
			if (Main.LocalPlayer.GetModPlayer<TaoPlayer>().HasMoonNecklace == true)
			{
				if (player.HeldItem.magic)
				{
					if (target.life <= 0)
					{
						player.statMana += Main.rand.Next(50, 86);
					}
				}
			}
			base.OnHitNPCWithProj(proj, target, damage, knockback, crit);
		}
	}
}
