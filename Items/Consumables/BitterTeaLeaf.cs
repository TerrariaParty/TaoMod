using Terraria;
using Terraria.ID;
using TaoMod.NPCs.Shaoyang;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace TaoMod.Items.Consumables 
{
    public class BitterTeaLeaf : ModItem
    {
        public override void SetStaticDefaults(){
			Tooltip.SetDefault("Summons the small ones depending on the time of day it's used");
        }
        public override void SetDefaults(){
            item.useStyle = 4;
            item.useTime = 45;
            item.useAnimation = 45;
            item.width = 36;
            item.height = 22;
            item.maxStack = 99;
            item.consumable = true;
            item.rare = 3;
        }
        public override bool CanUseItem(Player player){
            return (Main.dayTime && !NPC.AnyNPCs(NPCType<Shaoyang>()));
            //|| (!Main.dayTime && !NPC.AnyNPCs(NPCType<Shaoyin>())
        }
        public override bool UseItem(Player player){
            if(Main.dayTime)
	    {
	    NPC.NewNPC((int)player.position.X, (int)player.position.Y - 80, NPCType<Shaoyang>());
	    Main.NewText("Who has dared to challenge me? No matter, this will be your end, fool!");
	    }
            /*else
	    {
            NPC.SpawnOnPlayer(player.whoAmI, NPCType<Shaoyin>());
	    }*/
            Main.PlaySound(SoundID.Roar, player.position, 0);
            return true;
        }
        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StrangePlant1, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StrangePlant2, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StrangePlant3, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StrangePlant4, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}