using TaoMod.Projectiles.Minions;
using TaoMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.Items.Weapons
{
	public class AbyssalRiftStaff : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Tears a rift in reality\nRequires 2 minion slots to use");
			ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true;
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}

		public override void SetDefaults() {
			item.damage = 425;
			item.summon = true;
			item.mana = 10;
			item.width = 26;
			item.height = 28;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 30, 0, 0);
			item.rare = 11;
			item.scale = 1.2f;
			item.UseSound = SoundID.Item44;
			item.shoot = ProjectileType<AbyssalRift>();
			item.buffType = BuffType<Buffs.AbyssalRiftBuff>(); 
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
	}
}