using TaoMod.PartialPlayerClasses;
using Terraria;
using Terraria.ModLoader;

namespace TaoMod.Buffs
{
	public class Bleedingg : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Bleeding");
			Description.SetDefault("'You are bleeding!'");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<TaoPlayer>().pcBleeding = true;
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<TaoGlobalNPC>().pcBleeding = true;
		}
	}
}

//Yep, I had to create another bleeding