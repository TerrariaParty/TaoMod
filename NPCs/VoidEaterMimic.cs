using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TaoMod.Buffs;

namespace TaoMod.NPCs
{
	public class VoidEaterMimic : ModNPC
	{

		public override void SetStaticDefaults() {

			DisplayName.SetDefault("Void Eater Mimic"); 
			Main.npcFrameCount[npc.type] = 14; 
		}
		public override void SetDefaults() {
			npc.width = 68;
			npc.height = 54;
			npc.scale = 1f;
			npc.aiStyle = 87; 
            animationType = NPCID.BigMimicHallow;
			npc.damage = 90;
			npc.defense = 34;
			npc.lifeMax = 3500;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath6;
			npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.buffImmune[BuffID.CursedInferno] = true;
			npc.buffImmune[BuffID.Venom] = true;
			npc.buffImmune[BuffID.ShadowFlame] = true;
			npc.buffImmune[BuffType<AbyssalDebuff>()] = true;
			npc.knockBackResist = 0.9f;
			npc.noGravity = false;
			npc.value = 30000;
		}
	    public override void NPCLoot(){
			Item.NewItem(npc.getRect(), ItemID.GreaterHealingPotion, 10);
			Item.NewItem(npc.getRect(), ItemID.GreaterManaPotion, 10);
        }
    }
}
