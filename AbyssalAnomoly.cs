using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using VoidEncounter.Items.Materials;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VoidEncounter.NPCs
{
	public class AbyssalAnomoly : ModNPC
	{

		public override void SetStaticDefaults() {

			DisplayName.SetDefault("Abyssal Anomoly"); 
			Main.npcFrameCount[npc.type] = 1; 
		}
		public override void SetDefaults() {
			npc.width = 68;
			npc.height = 54;
			npc.scale = .6f;
			npc.aiStyle = -1; 
			npc.damage = 400;
			npc.defense = 30;
			npc.lifeMax = 1000;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.buffImmune[BuffID.Poisoned] = true;
            npc.buffImmune[BuffID.OnFire] = true;
			npc.buffImmune[BuffID.Confused] = true;
			npc.knockBackResist = 0f;
		    npc.velocity.Y = 0f;
			npc.noGravity = true;
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			return 0.05f;
		}
        public override void FindFrame(int frameHeight) {
            npc.spriteDirection = npc.direction;
    }
	    public override void NPCLoot(){
		    if (Main.rand.NextBool(5)) Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Materials.AbyssalFragment>(), Main.rand.Next(1, 6));
    }
}}