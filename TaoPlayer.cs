using Terraria;
using Terraria.ModLoader;

namespace TaoMod
{
    class TaoPlayer : ModPlayer
    {
        public int spiritMeterCurrent;
        public const int DefaultSpiritMeterMax = 100;
        public int spiritMeterMax;
        public int spiritMeterMax2;
        public float spiritMeterRegenRate;
        internal int spiritMeterRegenTimer = 0;

        public override void Initialize()
        {
            spiritMeterMax = DefaultSpiritMeterMax;
        }

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }
        private void ResetVariables()
        {
            spiritMeterRegenRate = 1f;
            spiritMeterMax2 = spiritMeterMax;
        }
        public override void PostUpdateMiscEffects()
        {
            UpdateResource();
        }
        private void UpdateResource()
        {
            spiritMeterRegenTimer++; 

            if (spiritMeterRegenTimer > 60 * spiritMeterRegenRate)
            {
                spiritMeterCurrent += 1;
                spiritMeterRegenTimer = 0;
            }

            spiritMeterCurrent = Utils.Clamp(spiritMeterCurrent, 0, spiritMeterMax2);
        }
    }
}
