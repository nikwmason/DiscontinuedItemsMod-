using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Buffers;

namespace DiscontinuedItemsMod.Projectiles.PAmazonDrone
{
    public class AmazonDrone : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 1;
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectiles.CloneDefaults(ProjectileID.BabyDino);
            AIType = ProjectileID.BabyDino;
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
            if (!player.dead && player.HasBuff(ModContent.BuffType<Buffs.DroneBuff>()))
            {
                Projectile.timeLeft = 2;
            }
        }
    }
}