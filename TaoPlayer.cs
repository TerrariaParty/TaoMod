using Microsoft.Xna.Framework;
using System;
using TaoMod.Items.Rapiers;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Graphics.Capture;

namespace TaoMod
{
    class TaoPlayer : ModPlayer
    {
        public bool parryActive;
        public int parryTimeLeft;
        public int parry_cooldown;
        private int _timeSinceLastImmuneGet;
        private int _immuneStrikes;

        public override void PostUpdate()
        {
            if (parryActive)
            {
                player.statDefense += 15;
            }
        }
        public void UpdateCollision()
        {
            for (int i = 0; i < 200; i++)
            {
                NPC npc = GetInstance<NPC>();
                bool flag = true;
                bool flag2 = false;
                bool num = CanParryAgainst(player.getRect(), npc.getRect(), Main.npc[i].velocity);
                float num2 = player.thorns;
                float knockback = 10f;
                if (num)
                {
                    num2 = 2f;
                    knockback = 5f;
                    flag = false;
                    flag2 = true;
                }
                if (num)
                {
                    GiveImmuneTimeForCollisionAttack(player.longInvince ? 60 : 30);
                    player.AddBuff(BuffID.ParryDamageBuff, 300, quiet: false);
                }
            }
        }
        public void GiveImmuneTimeForCollisionAttack(int time)
        {
            if (_timeSinceLastImmuneGet <= 20)
            {
                _immuneStrikes++;
            }
            else
            {
                _immuneStrikes = 1;
            }
            _timeSinceLastImmuneGet = 0;
            if (_immuneStrikes < 3)
            {
                player.immune = true;
                player.immuneNoBlink = true;
                player.immuneTime = time;
            }
        }
        public void TaoPlayerFrame()
        {
            if (parryActive)
            {
                player.bodyFrame.Y = player.height * 10;
            }
        }
        public bool CanParryAgainst(Rectangle blockingPlayerRect, Rectangle enemyRect, Vector2 enemyVelocity)
        {
            if (parryTimeLeft > 0 && Math.Sign(enemyRect.Center.X - blockingPlayerRect.Center.X) == player.direction && enemyVelocity != Vector2.Zero)
            {
                return !player.immune;
            }
            return false;
        }
        public void FuckVanillaCodeAllMyHomiesHateVanillaCode()
        {
            bool CanRightClick = player.selectedItem != 58 && player.controlUseTile && !player.tileInteractionHappened && player.releaseUseItem && !player.controlUseItem && !player.mouseInterface && !CaptureManager.Instance.Active && !Main.HoveringOverAnNPC && !Main.SmartInteractShowingGenuine;
            ParryFunc(CanRightClick);
        }
        public void ParryFunc(bool theGeneralCheck)
        {
            Item item = new Item();
            bool mouseRight = PlayerInput.Triggers.JustPressed.MouseRight;
            if (player.whoAmI != Main.myPlayer)
            {
                mouseRight = parryActive;
                theGeneralCheck = parryActive;
            }
            bool shouldParry = false;
            bool IsItARapier = player.inventory[player.selectedItem].type == ItemType<WoodenRapier>();
            if (theGeneralCheck && IsItARapier && !player.mount.Active && (item.useAnimation == 0 || mouseRight))
            {
                shouldParry = true;
            }
            if (parry_cooldown > 0)
            {
                parry_cooldown--;
                if (parry_cooldown == 0)
                {
                    Main.PlaySound(SoundID.MaxMana, player.Center);
                    for (int i = 0; i < 10; i++)
                    {
                        int num = Dust.NewDust(player.Center + new Vector2(player.direction * 6 + ((player.direction == -1) ? (-10) : 0), -14f), 10, 16, 45, 0f, 0f, 255, new Color(255, 100, 0, 127), (float)Main.rand.Next(10, 16) * 0.1f);
                        Main.dust[num].noLight = true;
                        Main.dust[num].noGravity = true;
                        Main.dust[num].velocity *= 0.5f;
                    }
                }
            }
            if (parryTimeLeft > 0 && ++parryTimeLeft > 20)
            {
                parryTimeLeft = 0;
            }
            TryTogglingParry(shouldParry);
        }
        public void TryTogglingParry(bool shouldParry)
        {
            Item item = new Item();
            if (shouldParry == parryActive)
            {
                return;
            }
            parryActive = shouldParry;
            if (parryActive)
            {
                if (parry_cooldown == 0)
                {
                    parryTimeLeft = 1;
                }
                item.useAnimation = 0;
                item.useTime = 0;
                item.reuseDelay = 0;
            }
            else
            {
                parry_cooldown = 15;
                parryTimeLeft = 0;
                if (player.attackCD < 20)
                {
                    player.attackCD = 20;
                }
            }
        }
    }
}
