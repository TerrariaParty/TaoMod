using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TaoMod.NPCs.Shaoyang
{
	public class YangSpear : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Spear of Yang");
		}

		public override void SetDefaults() {
			npc.aiStyle = 23;
			npc.lifeMax = 100;
			npc.damage = 20;
			npc.defense = 0;
			npc.knockBackResist = 0f;
			npc.dontTakeDamage = false;
			npc.width = 58;
			npc.height = 58;
			npc.lavaImmune = true;
            npc.scale = 1f;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit1;
            npc.velocity.X = 6f;
            npc.velocity.Y = 6f;
			npc.alpha = 60;
		}
		
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale) {
			npc.lifeMax = 200;
			npc.defense = 2;
			npc.damage = 40;
		}
        int SpeedUp = 0;
        public override void AI(){
            SpeedUp++;
            if(SpeedUp == 30){
                npc.velocity.X *= 1.25f;
				npc.velocity.Y *= 1.25f;
                SpeedUp = 0;
            }
        }
		public override void HitEffect(int hitDirection, double damage) {
			if (npc.life <= 0) {
				Gore.NewGore(npc.position + new Vector2(10f, 0f), Vector2.Zero, Main.rand.Next(61, 63), 2f);
			}
		}
	}
}