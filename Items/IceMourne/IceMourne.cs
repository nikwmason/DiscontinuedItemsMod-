using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace DiscontinuedItemsMod.Items.IceMourne
{
    public class IceMourne : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            
            Item.damage = 48;
            Item.knockBack = 6f;
            Item.DamageType = DamageClass.Melee;
            Item.crit = 6;
            
            Item.value = Item.buyPrice(0, 5, 0, 0); // 5 gold
            Item.rare = ItemRarityID.Pink;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.IceBlock, 50)
                .AddIngredient(ItemID.FrostCore, 1)
                .AddIngredient(ItemID.SoulofNight, 10)
                .AddIngredient(ItemID.HallowedBar, 12)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 
                    DustID.IceTorch, 0f, 0f, 150, default, 1.5f);
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frostburn, 180);
            if (Main.rand.NextBool(2))
            {
                target.AddBuff(BuffID.Frozen, 60);
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (Main.rand.NextBool(3))
            {
                Vector2 shootVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));
                Projectile.NewProjectile(source, position, shootVelocity * 1.5f, 
                    ProjectileID.FrostBlastFriendly, damage / 2, knockback, player.whoAmI);
            }
            return false;
        }
    }
}