using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace TaoMod
{
    class TaoWorld : ModWorld
    {
        public static int currentGemsGiven;
        public static bool givenFireGem;
        public static bool givenWaterGem;
        public static bool givenEarthGem;
        public static bool givenWoodGem;
        public static bool givenMetalGem;

        public override void Initialize()
        {
            currentGemsGiven = 0;
            givenFireGem = false;
            givenWaterGem = false;
            givenEarthGem = false;
            givenWoodGem = false;
            givenMetalGem = false;
        }
        public override TagCompound Save()
        {
            var gemsGiven = new List<string>();

            return new TagCompound
            {
                ["gemsGiven"] = gemsGiven,
            };
        }
        public override void Load(TagCompound tag)
        {
            var gemsGiven = tag.GetList<string>("gemsGiven");

            givenFireGem = gemsGiven.Contains("fire");
            givenWaterGem = gemsGiven.Contains("water");
            givenEarthGem = gemsGiven.Contains("earth");
            givenWoodGem = gemsGiven.Contains("wood");
            givenMetalGem = gemsGiven.Contains("metal");
        }
		public override void LoadLegacy(BinaryReader reader)
		{
			int loadVersion = reader.ReadInt32();
			if (loadVersion == 0)
			{
				BitsByte flags = reader.ReadByte();
				givenFireGem = flags[0];
				givenWaterGem = flags[1];
				givenEarthGem = flags[2];
				givenWoodGem = flags[3];
				givenMetalGem = flags[4];
			}
			else
			{
				mod.Logger.WarnFormat("Tao Mod: Unknown loadVersion: {0}", loadVersion);
			}
		}

		public override void NetSend(BinaryWriter writer)
		{
			var gems = new BitsByte();
			gems[0] = givenFireGem;
			gems[1] = givenWaterGem;
			gems[2] = givenEarthGem;
			gems[3] = givenWoodGem;
			gems[4] = givenMetalGem;
			writer.Write(gems);

			/*
			Remember that Bytes/BitsByte only have 8 entries. If you have more than 8 flags you want to sync, use multiple BitsByte:
				This is wrong:
			flags[8] = downed9thBoss; // an index of 8 is nonsense. 
				This is correct:
			flags[7] = downed8thBoss;
			writer.Write(flags);
			BitsByte flags2 = new BitsByte(); // create another BitsByte
			flags2[0] = downed9thBoss; // start again from 0
			// up to 7 more flags here
			writer.Write(flags2); // write this byte
			*/
		}

		public override void NetReceive(BinaryReader reader)
		{
			BitsByte gems = reader.ReadByte();
			givenFireGem = gems[0];
			givenWaterGem = gems[1];
			givenEarthGem = gems[2];
			givenWoodGem = gems[3];
			givenMetalGem = gems[4];
			// As mentioned in NetSend, BitBytes can contain 8 values. If you have more, be sure to read the additional data:
			// BitsByte flags2 = reader.ReadByte();
			// downed9thBoss = flags[0];
		}

	}
}
