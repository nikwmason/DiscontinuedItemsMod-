using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DiscontinuedItemsMod.Projectiles.PAmazonDrone
{
    public class PetName : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ZephyrFish);
            projectile.name = "Pet Drone";
            aiType = ProjectileID.ZephyrFish;
            Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.zephyrfish = false;
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
            
            if (player.dead)
            {
				modPlayer.Pet = false;
            }
            if (modPlayer.Pet)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}