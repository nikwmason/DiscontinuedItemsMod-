using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DiscontinuedItemsMod.Pets.BAmazonDrone
{
    public class AmazonDrone : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
            Main.projPet[Projectile.type] = true;
            Main.projPetLight[Projectile.type] = false;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ZephyrFish);
            AIType = ProjectileID.ZephyrFish;
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            player.zephyrfish = false;
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (!player.dead && player.HasBuff(ModContent.BuffType<Pets.BAmazonDrone.DroneBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            if (++Projectile.frameCounter >= 6)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 4)
                {
                    Projectile.frame = 0;
                }
            }
        }
    }
}