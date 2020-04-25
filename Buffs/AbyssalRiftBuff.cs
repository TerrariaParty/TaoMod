using TaoMod.PartialPlayerClasses;
using Terraria;
using Terraria.ModLoader;

namespace TaoMod.Buffs
{
	public class AbyssalRiftBuff : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Abyssal Rift");
			Description.SetDefault("The abyssal rift will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			TaoPlayer modPlayer = player.GetModPlayer<TaoPlayer>();
			if (player.ownedProjectileCounts[mod.ProjectileType("AbyssalRift")] > 0) {
				modPlayer.riftMinion = true;
			}
			if (!modPlayer.riftMinion) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}