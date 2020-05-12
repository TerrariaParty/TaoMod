using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TaoMod.Items.Accessories.Other;
using static Terraria.ModLoader.ModContent;
using TaoMod.Items.Materials;

class TaoGlobalNPC : GlobalNPC
{
	public override void NPCLoot(NPC npc)
	{
		if (npc.type == NPCID.WallofFlesh && Main.expertMode)
		{
			if (Main.rand.Next(6) == 0)
			{
				Item.NewItem(npc.getRect(), ItemType<AbyssalEmblem>(), 1);
			}
		}
		if (npc.type == NPCID.BlueSlime || npc.type == NPCID.GreenSlime || npc.type == NPCID.BlackSlime || npc.type == NPCID.PurpleSlime || npc.type == NPCID.YellowSlime || npc.type == NPCID.RedSlime || npc.type == NPCID.UmbrellaSlime || npc.type == NPCID.Slimeling || npc.type == NPCID.Slimer || npc.type == NPCID.Slimer2 || npc.type == NPCID.SlimeRibbonGreen || npc.type == NPCID.SlimeRibbonRed || npc.type == NPCID.SlimeRibbonWhite || npc.type == NPCID.SlimeRibbonYellow || npc.type == NPCID.SlimeSpiked || npc.type == NPCID.CorruptSlime || npc.type == NPCID.DungeonSlime || npc.type == NPCID.IceSlime || npc.type == NPCID.IlluminantSlime || npc.type == NPCID.JungleSlime || npc.type == NPCID.MotherSlime || npc.type == NPCID.LavaSlime || npc.type == NPCID.BabySlime || npc.type == NPCID.SandSlime || npc.type == NPCID.RainbowSlime)
		{
			if (Main.rand.Next(11) == 0)
			{
				Item.NewItem(npc.getRect(), ItemType<SlimeCore>(), Main.rand.Next(1,3));
			}
		}
		// Addtional if statements here if you would like to add drops to other vanilla npc.
	}
	public bool abyssalDebuff = false;
	public bool pcBleeding = false;
	public override bool InstancePerEntity => true;
	    public override void ResetEffects(NPC npc)
        {
			abyssalDebuff = false;
			pcBleeding = false;
        }
 
        public override void UpdateLifeRegen(NPC npc, ref int damage) {
			if (abyssalDebuff){
				npc.lifeRegen -= 20;
			}
			if (pcBleeding)
		{
			npc.lifeRegen -= 30;
		}
		}
}
