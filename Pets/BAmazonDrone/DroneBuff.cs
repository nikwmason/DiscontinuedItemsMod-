using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiscontinuedItemsMod.Pets.BAmazonDrone
{
	public class DroneBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.buffTime[buffIndex] = 18000;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Pets.BAmazonDrone.AmazonDrone>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center, Microsoft.Xna.Framework.Vector2.Zero,
					ModContent.ProjectileType<Pets.BAmazonDrone.AmazonDrone>(), 0, 0f, player.whoAmI);
			}
		}
	}
}