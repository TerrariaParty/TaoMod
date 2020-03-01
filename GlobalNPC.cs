using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

class MyGlobalNPC : GlobalNPC
{
	public override void NPCLoot(NPC npc)
	{
		if(npc.type == NPCID.SkeletronHead)
		{
			// if (Main.rand.Next(7) == 0)
		}
		// Addtional if statements here if you would like to add drops to other vanilla npc.
	}
}