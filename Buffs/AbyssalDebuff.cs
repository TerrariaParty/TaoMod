using TaoMod;
using Terraria;
using Terraria.ModLoader;

namespace TaoMod.Buffs
{
	public class AbyssalDebuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Abyssal Flames");
			Description.SetDefault("'Losing your mind to the grasps of the Abyss'");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<TaoPlayer>().abyssalDebuff = true;
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<TaoGlobalNPC>().abyssalDebuff = true;
		}
	}
}