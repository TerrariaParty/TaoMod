using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using VoidEncounter.Items.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace VoidEncounter.Items.Weapons
{
	public class VoidSeersMallet : ModItem
	{
		public override void SetStaticDefaults() {
            DisplayName.SetDefault("Void Seer's Mallet");
			Tooltip.SetDefault("Conjures a hammer out of energy that rotates around you then slowly distances itself away from you\nRight click to fire a more precise, aimed hammer that does less damage");
		}

		public override void SetDefaults() {
			item.damage = 65;
			item.crit = 5;
			item.magic = true;
			item.shootSpeed = 16f;
			Item.staff[item.type] = true;
			item.width = 52;
			item.height = 50;
			item.mana = 14;
			item.useTime = 32;
			item.useAnimation = 32;   
			item.useStyle = 5;
			item.knockBack = 6;
			item.rare = 11;
			item.UseSound = SoundID.Item43;
			item.noMelee = true;
			item.autoReuse = true;
            item.shoot = ProjectileType<VoidHammerProjectile>();
			item.value = Item.buyPrice(1, 0, 0, 0);
		}
		public override bool AltFunctionUse(Player player) {

			return true;

		}
		public override bool CanUseItem(Player player) {

			if (player.altFunctionUse == 2) {
				item.useStyle = 5;
				item.useTime = 30;
				item.useAnimation = 30;
				item.damage = 55;
				item.shoot = ProjectileType<VoidHammerProjectileAlt>();
			}
			else {
				item.useStyle = 5;
				item.useTime = 32;
				item.useAnimation = 32;
				item.damage = 65;
				item.shoot = ProjectileType<VoidHammerProjectile>();
			}

			return base.CanUseItem(player);

		}
    }
}