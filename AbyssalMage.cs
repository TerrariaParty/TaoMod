using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using VoidEncounter.Items.Materials;
using VoidEncounter.Items.Weapons;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using VoidEncounter.Items.Projectiles;


namespace VoidEncounter.NPCs
{
	// [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
	[AutoloadHead]
	public class AbyssalMage : ModNPC
	{
		public override string Texture => "VoidEncounter/NPCs/AbyssalMage";

		public override bool Autoload(ref string name) {
			name = "Abyssal Mage";
			return mod.Properties.Autoload;
		}
        public override void SetStaticDefaults() {
			// DisplayName automatically assigned from .lang files, but the commented line below is the normal approach.
			// DisplayName.SetDefault("Example Person");
			Main.npcFrameCount[npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 40;
		}
        public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 32;
			npc.height = 50;
			npc.aiStyle = 7;
			npc.damage = 20;
			npc.defense = 20;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
            for (int k = 0; k < 255; k++) {
                Player player = Main.player[k];
                if (!player.active) {
                    continue;
                }
                if (player.HasItem(ModContent.ItemType<AbyssalFragment>())) {
                    return true;
                }
            }
            return false;
        }
		 public override string TownNPCName() {
			switch (WorldGen.genRand.Next(4)) {
				case 0:
					return "R’lyeh";
				case 1:
					return "B'gnu-Thun";
				case 2:
					return "Azathoth";
				default:
					return "Shoggoth";
			}
        }
        public override string GetChat() {
			int wizard = NPC.FindFirstNPC(NPCID.Wizard);
			if (wizard >= 0 && Main.rand.NextBool(4)) {
				return "That " + Main.npc[wizard].GivenName + " knows nothing about real magic.";
			} 
			switch (Main.rand.Next(4)) {
				case 0:
					return "What do you want? I've got to create a new world-ender by the end of next week!";
				case 1:
					return "Wha? I have the name of a mythical god? I'm flattered, but don't be ridiculous.";
			    case 2:
				    return "What's that? Manu you say? Yeah, I don't know them either.";
				default:
					return "How do I talk without a mouth? Well, it's complicated.";
			}
            }
		public override void SetChatButtons(ref string button, ref string button2) {

			button = Language.GetTextValue("LegacyInterface.28");
			if (Main.LocalPlayer.HasItem(ItemType<AbyssalFragment>()))
				button = "Show Abyssal Fragment";
		}
		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {

			if (firstButton) {}
			if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
				{
					Main.npcChatText = $"What's that you have the- ?! How'd you get your hands on an Abyssal Fragment? These are rare, even in the abyss! Hm... maybe... Come back to me later. I might have something for you.";
					return;
				}
                shop = true;
			}
		public override void SetupShop(Chest shop, ref int nextSlot) {
			shop.item[nextSlot].SetDefaults(ItemType<VoidSeersMallet>());
			nextSlot++;
        }
        public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 20;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 30;
			randExtraCooldown = 0;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ProjectileID.DeathSickle;
			attackDelay = 0;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
		}
	}
}
