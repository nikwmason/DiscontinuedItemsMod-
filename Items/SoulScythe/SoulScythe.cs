using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace DiscontinuedItemsMod.Items.SoulScythe
{
    public class SoulScythe : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item71;
            
            Item.damage = 58;
            Item.knockBack = 7f;
            Item.DamageType = DamageClass.Melee;
            Item.crit = 8; 
            
            Item.value = Item.buyPrice(0, 8, 0, 0);
            Item.rare = ItemRarityID.Lime;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.SoulofNight, 15)
                .AddIngredient(ItemID.SoulofLight, 15)
                .AddIngredient(ItemID.Ectoplasm, 12)
                .AddIngredient(ItemID.SpectreBar, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(2))
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 
                    DustID.Shadowflame, 0f, 0f, 150, default, 1.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0.5f;
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.ShadowFlame, 180);
            if (hit.Crit)
            {
                int healAmount = (int)(damageDone * 0.1f);
                if (healAmount > 0)
                {
                    player.statLife += healAmount;
                    player.HealEffect(healAmount);
                }
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (Main.rand.NextBool(5, 2))
            {
                for (int i = 0; i < 2; i++)
                {
                    Vector2 shootVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));
                    Projectile.NewProjectile(source, position, shootVelocity, 
                        ProjectileID.LostSoulFriendly, damage / 3, knockback * 0.5f, player.whoAmI);
                }
            }
            return false;
        }
    }
}