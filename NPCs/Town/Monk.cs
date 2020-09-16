using Microsoft.Xna.Framework;
using TaoMod.Items.Accessories;
using TaoMod.Items.Materials;
using TaoMod.Items.QuestItems;
using TaoMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.NPCs.Town
{
    [AutoloadHead]
    public class Monk : ModNPC
    {
        public override string Texture => "TaoMod/NPCs/Town/Monk";
        public override bool Autoload(ref string name)
        {
            name = "Monk";
            return mod.Properties.Autoload;
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 26;
            NPCID.Sets.ExtraFramesCount[npc.type] = 0;
            NPCID.Sets.AttackFrameCount[npc.type] = 5;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 2;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }
        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 26;
            npc.height = 46;
            npc.aiStyle = 7;
            npc.damage = 50;
            npc.defense = 20;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.downedBoss2)
            {
                return true;
            }
            return false;
        }
        public bool projActive = false;
        public int projTimer = 120;
        public override void AI()
        {
            if (!projActive && projTimer == 0 && npc.frameCounter == 22 || npc.frameCounter == 23 || npc.frameCounter == 24 || npc.frameCounter == 25 || npc.frameCounter == 26)
            {
                if (Main.hardMode)
                {
                    Projectile.NewProjectile(npc.Center, Vector2.Zero, ProjectileType<MonkDamageCircle>(), 75, 0.1f, Main.myPlayer, npc.whoAmI);
                }
                else
                {
                    Projectile.NewProjectile(npc.Center, Vector2.Zero, ProjectileType<MonkDamageCircle>(), 30, 0.05f, Main.myPlayer, npc.whoAmI);
                }
                projActive = true;
            }

            if (projActive)
            {
                projTimer--;
            }
        }
        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(8))
            {
                case 0:
                    return "Sun Tzu";
                case 1:
                    return "Wenzi";
                case 2:
                    return "Lie Yukou";
                case 3:
                    return "Zhuang Zi";
                case 4:
                    return "Guiguzi";
                case 5:
                    return "Zhongli Quan";
                case 6:
                    return "Wang Bi";
                case 7:
                    return "Zhang Sanfeng";
                default:
                    return "Laozi";
            }
        }
        public override string GetChat()
        {
            int guide = NPC.FindFirstNPC(NPCID.Guide);
            int cyborg = NPC.FindFirstNPC(NPCID.Cyborg);
            string currentName = npc.GivenName;
            if (guide >= 0 && Main.rand.NextBool(4))
            {
                return "I thought I knew the answers, turns out that I don't! I've been talking to " + Main.npc[guide].GivenName + ". He seems nice. He certainly keeps a lot of information in his noggin of his!";
            }
            if (currentName == "Sun Tzu" && cyborg >= 0 && Main.rand.NextBool(4))
            {
                return Main.npc[cyborg].GivenName + " showed me something called the 'internet' yesterday. I saw all these pictures of people quoting me about things I've never said once in my life! Who are these people and why are they quoting me?";
            }
            if (TaoWorld.currentGemsGiven == 0 && Main.rand.NextBool(4))
            {
                switch (Main.rand.Next(6))
                {
                    case 1:
                        {
                            Main.npcChatCornerItem = ItemType<OrnateGemHuo>();
                            return $"Hey, have you found a [i:{ItemType<OrnateGemHuo>()}]? Some say it can grant manipulation over flames.";
                        }
                    case 2:
                        {
                            Main.npcChatCornerItem = ItemType<OrnateGemShui>();
                            return $"Did you happen to find a [i:{ItemType<OrnateGemShui>()}] yet? Rumors state it can grant manipulation over the waves.";
                        }
                    case 3:
                        {
                            Main.npcChatCornerItem = ItemType<OrnateGemTu>();
                            return $"Hey, have you found a [i:{ItemType<OrnateGemTu>()}]? Some say it can grant manipulation over the very ground we stand on.";
                        }
                    case 4:
                        {
                            Main.npcChatCornerItem = ItemType<OrnateGemMu>();
                            return $"Did you happen to find a [i:{ItemType<OrnateGemMu>()}] yet? Rumors state it can grant manipulation over vast forests and plants.";
                        }
                    case 5:
                        {
                            Main.npcChatCornerItem = ItemType<OrnateGemJin>();
                            return $"Hey, have you found a [i:{ItemType<OrnateGemJin>()}]? Some say it can grant manipulation over metals.";
                        }
                }
            }
            if (TaoWorld.currentGemsGiven > 0 && Main.rand.NextBool(4))
            {
                return "As it turns out, the gems appear to produce a fine powder that has a fraction of the gems actual power! I don't actually have any use for it, maybe you'll find something to do with it?";
            }
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "I'm just not as fit as I used to be. In my prime, I could have broken your bones!";
                case 1:
                    return "Sometimes I wonder if there's more to this world than balance.";
                default:
                    return "I've travelled around the world seeking wisdom. This village does not disappoint with knowledge as well.";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "Quest";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
            else
            {
                Player player = Main.player[Main.myPlayer];

                foreach (Item item in player.inventory)
                {
                    if (item.type == ItemType<OrnateGemHuo>())
                    {
                        Main.npcChatText = "Hm? What's that? Oh! You have the Ornate Gem of Huo! Good job. Here, take this for your troubles.";
                        item.TurnToAir();
                        player.QuickSpawnItem(ItemID.GoldCoin, 5);
                        TaoWorld.givenFireGem = true;
                        TaoWorld.currentGemsGiven += 1;
                    }
                    else if (item.type == ItemType<OrnateGemShui>())
                    {
                        Main.npcChatText = "Hm? What's that? Oh! You have the Ornate Gem of Shui! Good job. Here, take this for your troubles.";
                        item.TurnToAir();
                        player.QuickSpawnItem(ItemID.GoldCoin, 5);
                        TaoWorld.givenWaterGem = true;
                        TaoWorld.currentGemsGiven += 1;
                    }
                    else if (item.type == ItemType<OrnateGemTu>())
                    {
                        Main.npcChatText = "Hm? What's that? Oh! You have the Ornate Gem of Tu! Good job. Here, take this for your troubles.";
                        item.TurnToAir();
                        player.QuickSpawnItem(ItemID.GoldCoin, 5);
                        TaoWorld.givenEarthGem = true;
                        TaoWorld.currentGemsGiven += 1;
                    }
                    else if (item.type == ItemType<OrnateGemMu>())
                    {
                        Main.npcChatText = "Hm? What's that? Oh! You have the Ornate Gem of Mu! Good job. Here, take this for your troubles.";
                        item.TurnToAir();
                        player.QuickSpawnItem(ItemID.GoldCoin, 5);
                        TaoWorld.givenWoodGem = true;
                        TaoWorld.currentGemsGiven += 1;
                    }
                    else if (item.type == ItemType<OrnateGemJin>())
                    {
                        Main.npcChatText = "Hm? What's that? Oh! You have the Ornate Gem of Jin! Good job. Here, take this for your troubles.";
                        item.TurnToAir();
                        player.QuickSpawnItem(ItemID.GoldCoin, 5);
                        TaoWorld.givenMetalGem = true;
                        TaoWorld.currentGemsGiven += 1;
                    }
                    else
                    {
                        if (TaoWorld.currentGemsGiven == 0)
                        {
                            Main.npcChatText = "Hm? You want a job? Well, I'm currently looking for the Wuxing Gems. Essentially, they would grant incredible power to the wielder of all 5; master of fire, water, earth, wood and metal. Now don't get me wrong, I'm not power hungry. I simply wish to keep them safe and away from harms way. I'll also reward you well for your troubles. How about it?";
                        }
                        else if (TaoWorld.currentGemsGiven > 0 && TaoWorld.currentGemsGiven < 5 && !(player.HasItem(ItemType<OrnateGemHuo>()) || player.HasItem(ItemType<OrnateGemShui>()) || player.HasItem(ItemType<OrnateGemTu>()) || player.HasItem(ItemType<OrnateGemMu>()) || player.HasItem(ItemType<OrnateGemJin>())))
                        {
                            Main.npcChatText = $"Well, you've already found {TaoWorld.currentGemsGiven} out of 5 gems, get out there and find the rest! My body isnt as good as it used to be y'know?";
                        }
                        else if (TaoWorld.currentGemsGiven == 5)
                        {
                            Main.npcChatText = "Well, you've already found all of the Wuxing Gems. I don't need anything else done. Now leave me alone to meditate in peace.";
                        }
                    }
                }
            }
        }
        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemType<EmptyAmulet>());
            nextSlot++;
            if (TaoWorld.givenFireGem)
            {
                shop.item[nextSlot].SetDefaults(ItemType<DustHuo>());
                nextSlot++;
            }
            if (TaoWorld.givenWaterGem)
            {
                nextSlot++;
            }
            if (TaoWorld.givenEarthGem)
            {
                nextSlot++;
            }
            if (TaoWorld.givenWoodGem)
            {
                nextSlot++;
            }
            if (TaoWorld.givenMetalGem)
            {
                nextSlot++;
            }
        }
        public override void NPCLoot()
        {
            for (int i = 0; i < 3; i++)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/Monk_Gore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/Monk_Gore2"), 1f);
            }
            Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/Monk_Gore3"), 1f);
        }
        public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
        }
    }
}