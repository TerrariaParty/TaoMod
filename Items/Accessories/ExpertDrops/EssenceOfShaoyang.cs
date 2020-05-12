using TaoMod.PartialPlayerClasses;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TaoMod.Items.Accessories.ExpertDrops
{
	public class EssenceOfShaoyang : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("6 defense\n+50 max life\nReduces all damage by 20%\nOn hit spears of yang will fall down from the sky");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(4, 25));
		}

		public override void SetDefaults()
		{
			item.width = 34;
			item.height = 34;
			item.accessory = true;
			item.value = Item.sellPrice(platinum: 0, gold: 1, silver: 45);
			item.rare = -12;
			item.expert = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statDefense += 6;
			player.statLifeMax2 += 50;
			player.allDamage -= 0.20f;
			player.GetModPlayer<TaoPlayer>().HasEssenceOfShaoyang = true;
		}
	}
}