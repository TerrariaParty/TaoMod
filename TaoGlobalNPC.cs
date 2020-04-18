using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using TaoMod.Items.Accessories;
using static Terraria.ModLoader.ModContent;
using TaoMod.Buffs;

class TaoGlobalNPC : GlobalNPC
{
	public override void NPCLoot(NPC npc)
	{
		if(npc.type == NPCID.WallofFlesh && Main.expertMode)
		{
			if (Main.rand.Next(6) == 0) {
				Item.NewItem(npc.getRect(), ItemType<AbyssalEmblem>(), 1);
			}
		}
		// Addtional if statements here if you would like to add drops to other vanilla npc.
	}
	public bool abyssalDebuff = false;
	public bool earthDebuff = false;
	public override bool InstancePerEntity => true;
	    public override void ResetEffects(NPC npc)
        {
			abyssalDebuff = false;
			earthDebuff = false;
        }
 
        public override void UpdateLifeRegen(NPC npc, ref int damage) {
			if (abyssalDebuff){
				npc.lifeRegen -= 20;
			}
			if (earthDebuff){
				npc.lifeRegen -= 10;
			}
		}
}