using Terraria;
using Terraria.ModLoader;

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
			player.GetModPlayer<MyPlayer>().Pet = true;	

			bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("AmazonDrone")] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.GetSource_Buff(buffIndex), player.Center,
					Microsoft.Xna.Framework.Vector2.Zero, ModContent.ProjectType<AmazonDrone>(), 0, 0f, player.whoAmI);
			}
		}
	}
}