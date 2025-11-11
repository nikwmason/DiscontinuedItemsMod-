using Terraria;
using Terraria.ModLoader;

namespace DiscontinuedItemsMod
{
    public class MyPlayer : ModPlayer
    {
		public bool minionName = false;
		public static bool hasProjectile;
		public bool Pet = false;
        public override void ResetEffects()
        {
            Pet = false;
			minionName = false;
        }
    }
}