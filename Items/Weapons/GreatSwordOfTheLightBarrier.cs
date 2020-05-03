using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TaoMod.Projectiles;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using TaoMod.PartialPlayerClasses;

namespace TaoMod.Items.Weapons
{
	public class GreatSwordOfTheLightBarrier : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Greatsword of the Light Barrier"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Simply holding this sword grants the user resilience, though it is very heavy");
		}

		public override void SetDefaults()
		{
			item.damage = 37;
			item.melee = true;
			item.width = 68;
			item.height = 68;
			item.useTime = 35;
			item.useAnimation = 35;
			item.useStyle = 1;
			item.knockBack = 7;
			item.value = Item.sellPrice(gold: 2);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
		public override void HoldItem(Player player)
		{
			player.AddBuff(BuffID.Slow, 1);
			player.statDefense += 7;
		}
	}
	}

//Once a tank, always a tank