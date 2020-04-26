using Terraria;
using Terraria.ModLoader;
using TaoMod.Buffs;
using System;
using Microsoft.Xna.Framework;
using TaoMod.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.PartialPlayerClasses
{
	public partial class TaoPlayer : ModPlayer
	{
		public bool HasVoidGazersMirror;
		public bool HasSoulbinder;
		public bool HasMoonNecklace;
		public bool HasBloodDagger;
		public bool HasEnchantedScabbard;
		public bool HasEssenceOfShaoyang;
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
		public override void OnHitByNPC(NPC npc, int damage, bool crit)
		{
			if (Main.LocalPlayer.GetModPlayer<TaoPlayer>().HasEssenceOfShaoyang == true)
			{
				for (int i = 0; i < 3; i++)
				{
					float positionX = player.position.X + (float)Main.rand.Next(-400, 400);
					float positionY = player.position.Y - (float)Main.rand.Next(500, 800);
					Vector2 vector = new Vector2(positionX, positionY);
					float speedX = player.position.X + (float)(player.width / 2) - vector.X;
					float speedY = player.position.Y + (float)(player.height / 2) - vector.Y;
					speedX += (float)Main.rand.Next(-100, 101);
					float num40 = (float)Math.Sqrt((double)(speedX * speedX + speedY * speedY));
					num40 = 23f / num40;
					speedX *= num40;
					speedY *= num40;
					int spawnspear = Projectile.NewProjectile(positionX, positionY, speedX, speedY, ProjectileType<SpearOfYang>(), Main.rand.Next(15, 20), 1.25f, player.whoAmI, 0f, 0f);
					Main.projectile[spawnspear].ai[1] = player.position.Y;
				}
			}
			base.OnHitByNPC(npc, damage, crit);
		}
		public override void OnHitByProjectile(Projectile proj, int damage, bool crit)
		{
			if (Main.LocalPlayer.GetModPlayer<TaoPlayer>().HasEssenceOfShaoyang == true)
			{
				for (int i = 0; i < 3; i++)
				{
					float positionX = player.position.X + (float)Main.rand.Next(-400, 400);
					float positionY = player.position.Y - (float)Main.rand.Next(500, 800);
					Vector2 vector = new Vector2(positionX, positionY);
					float speedX = player.position.X + (float)(player.width / 2) - vector.X;
					float speedY = player.position.Y + (float)(player.height / 2) - vector.Y;
					speedX += (float)Main.rand.Next(-100, 101);
					float num40 = (float)Math.Sqrt((double)(speedX * speedX + speedY * speedY));
					num40 = 23f / num40;
					speedX *= num40;
					speedY *= num40;
					int spawnspear = Projectile.NewProjectile(positionX, positionY, speedX, speedY, ProjectileType<SpearOfYang>(), Main.rand.Next(15, 20), 1.25f, player.whoAmI, 0f, 0f);
					Main.projectile[spawnspear].ai[1] = player.position.Y;
				}
			}
			base.OnHitByProjectile(proj, damage, crit);
		}
		public override void OnHitPvp(Item item, Player target, int damage, bool crit)
		{
			if (Main.LocalPlayer.GetModPlayer<TaoPlayer>().HasEssenceOfShaoyang == true)
			{
				for (int i = 0; i < 3; i++)
				{
					float positionX = player.position.X + (float)Main.rand.Next(-400, 400);
					float positionY = player.position.Y - (float)Main.rand.Next(500, 800);
					Vector2 vector = new Vector2(positionX, positionY);
					float speedX = player.position.X + (float)(player.width / 2) - vector.X;
					float speedY = player.position.Y + (float)(player.height / 2) - vector.Y;
					speedX += (float)Main.rand.Next(-100, 101);
					float num40 = (float)Math.Sqrt((double)(speedX * speedX + speedY * speedY));
					num40 = 23f / num40;
					speedX *= num40;
					speedY *= num40;
					int spawnspear = Projectile.NewProjectile(positionX, positionY, speedX, speedY, ProjectileType<SpearOfYang>(), Main.rand.Next(15, 20), 1.25f, player.whoAmI, 0f, 0f);
					Main.projectile[spawnspear].ai[1] = player.position.Y;
				}
			}
			base.OnHitPvp(item, target, damage, crit);
		}
		public override void OnHitPvpWithProj(Projectile proj, Player target, int damage, bool crit)
		{
			if (Main.LocalPlayer.GetModPlayer<TaoPlayer>().HasEssenceOfShaoyang == true)
			{
				for (int i = 0; i < 3; i++)
				{
					float positionX = player.position.X + (float)Main.rand.Next(-400, 400);
					float positionY = player.position.Y - (float)Main.rand.Next(500, 800);
					Vector2 vector = new Vector2(positionX, positionY);
					float speedX = player.position.X + (float)(player.width / 2) - vector.X;
					float speedY = player.position.Y + (float)(player.height / 2) - vector.Y;
					speedX += (float)Main.rand.Next(-100, 101);
					float num40 = (float)Math.Sqrt((double)(speedX * speedX + speedY * speedY));
					num40 = 23f / num40;
					speedX *= num40;
					speedY *= num40;
					int spawnspear = Projectile.NewProjectile(positionX, positionY, speedX, speedY, ProjectileType<SpearOfYang>(), Main.rand.Next(15, 20), 1.25f, player.whoAmI, 0f, 0f);
					Main.projectile[spawnspear].ai[1] = player.position.Y;
				}

			}
			base.OnHitPvpWithProj(proj, target, damage, crit);
		}
	}
}
