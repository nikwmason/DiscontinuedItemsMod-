using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace DiscontinuedItemsMod.Items.IceMourne
{
	public class Icemourne : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Icemourne";
			item.damage = 44;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.toolTip = "The Icemourne";
			item.useTime = 31;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = 300;
			item.rare = 4;
			item.useSound = 1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Sparkle"));
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Frozen, 15);
		}
	}}