using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace DiscontinuedItemsMod.Pets.BAmazonDrone
{
    public class AmazonDrone : ModProjectile
    {
        private int frameCounter = 0;
        private int frame = 0;
        private const int AnimationSpeed = 6;
        private const int FrameCount = 4;

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = FrameCount;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.BabyDino);
            AIType = ProjectileID.BabyDino;

            Projectile.width = 32;
            Projectile.length = 32;
        }

        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            player.dino = false;
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if (!player.dead && player.HasBuff(ModContent.BuffType<Pets.BAmazonDrone.DroneBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            AnimateDrone();
        }
        private void AnimateDrone()
        {
            frameCounter++;
            if (frameCounter >= AnimationSpeed)
            {
                frameCounter = 0;
                frame = (frame + 1) % FrameCount; //Cycles thru 1,2,3,4
            }
            
            Projectile.frame = frame;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            return true;
        }
    }
}