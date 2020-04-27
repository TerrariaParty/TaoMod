using Terraria.UI;

namespace TaoMod.UI
{
    public class SpiritSlot : UIState
    {
        public ItemSlot itemslot;

        public override void OnInitialize()
        {
            base.OnInitialize();
            itemslot = new ItemSlot();
            this.Left.Set(100, 0);
            this.Top.Set(0, 0.5f);
            this.Append(itemslot);
        }
    }
}