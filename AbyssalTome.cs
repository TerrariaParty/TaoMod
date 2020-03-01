using VoidEncounter.Items.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace VoidEncounter.Items.Weapons
{
	public class AbyssalTome : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Abyssal Tome");
			Tooltip.SetDefault("'The writing is writen in an unknown language'");
		}

		public override void SetDefaults() {
			item.damage = 60;
            item.crit = -10000;
			item.magic = true;
			item.mana = 25;
			item.width = 28;
			item.height = 30;
			item.useTime = 300;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 0;
			item.value = Item.buyPrice(0, 75, 0, 0);
			item.rare = 11;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shoot = ProjectileType<AbyssalTomeProjectile>();
		}
        public override bool CanUseItem(Player player) {
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
	}
}