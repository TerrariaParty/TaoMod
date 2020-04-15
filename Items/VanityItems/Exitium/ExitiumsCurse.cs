using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TaoMod.Items.VanityItems.Exitium;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.Items.VanityItems.Exitium
{
	[AutoloadEquip(EquipType.Head)]
	public class ExitiumsCurse : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Exitium's Curse");
			Tooltip.SetDefault("'Great for impersonating developers!'");
		}
        public override void SetDefaults()
        {
            item.width = 22; //The size in width of the sprite in pixels.
            item.height = 20;   //The size in height of the sprite in pixels.
            item.rare = 9;    //The color the title of your item when hovering over it ingame 
            item.vanity = true; //this defines if this item is vanity or not.
        }

        public override bool DrawHead()
        {
            return false;     //this make so the player head does not disappear when the vanity mask is equipped.  return false if you want to not show the player head.
        }
        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = false;  //this make so the player hair does not show when the vanity mask is equipped.  add true if you want to show the player hair.
        }
        public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == ItemType<ExitiumsGarb>() && legs.type == ItemType<ExitiumsPants>();
		}
        public override void ArmorSetShadows (Player player){
            player.armorEffectDrawShadow = true;
            player.armorEffectDrawShadowSubtle = true;
            player.armorEffectDrawShadowLokis = true;
            player.armorEffectDrawShadowBasilisk = true;
            player.armorEffectDrawShadowEOCShield = true;
        }
    }
}