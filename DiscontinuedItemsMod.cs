using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace DiscontinuedItemsMod
{
    class DiscontinuedItemsMod : Mod
    {
        public DiscontinuedItemsMod()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
    }

}
